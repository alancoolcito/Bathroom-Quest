using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed;
    [SerializeField] float slideSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] GameObject character;
    [SerializeField] Animator anim;

    private Rigidbody rigid;
    private float ScreenWidth;
    private GameObject floor;
    private bool startRunning;

    private bool isGrounded = true;

    [SerializeField] Canvas gameover;

    void Start()
    {
        ScreenWidth = Screen.width;
        rigid = character.GetComponent<Rigidbody>();
        floor = GameObject.FindGameObjectWithTag("Floor");
        startRunning = false;
      
    }

    void Update()
    {
        if (startRunning == true)
        {
            transform.position += Vector3.forward * runSpeed * Time.deltaTime;
        }

        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 1.35)
            {
                Slide(1f);
                Debug.Log("Right");
            }

            if (Input.GetTouch(i).position.x < ScreenWidth / 4)
            {
                Slide(-1f);
                Debug.Log("Left");
            }
            ++i;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
#if UNITY_EDITOR
        Slide(Input.GetAxis("Horizontal"));
#endif
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }

    private void Slide(float SlideSide)
    {
        transform.position += new Vector3(SlideSide * slideSpeed * Time.deltaTime, 0);
    }

    //public void SlideLeft()
    //{
    //    transform.position += Vector3.left * slideSpeed * Time.deltaTime;
    //}
    //public void SlideRight()
    //{
    //    transform.position += Vector3.right * slideSpeed * Time.deltaTime;
    //}

    public void Jump()
    {
        if (isGrounded == true)
        {
            rigid.AddForce(transform.up * jumpSpeed * Time.fixedDeltaTime);
            anim.SetTrigger("isJumping");
        }
    }

    public void Die()
    {
        runSpeed = 0;
        slideSpeed = 0;
        jumpSpeed = 0;
        anim.SetBool("isFalling", true);
        gameover.gameObject.SetActive(true);

        //Invoke("Restart", 2f);
    }

    public void Victory()
    {
        runSpeed = 0;
        slideSpeed = 0;
        jumpSpeed = 0;
        anim.SetBool("Win", true);
    }

    private void Restart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void StartRun()
    {
        startRunning = true;
    }

    public void DebugSpeed(float newRunSpeed)
    {
        runSpeed = newRunSpeed;
    }

    public void DebugJump(float newJumpSpeed)
    {
        jumpSpeed = newJumpSpeed;
    }
}

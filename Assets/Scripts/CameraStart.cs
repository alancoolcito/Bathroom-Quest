using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStart : MonoBehaviour
{
    private Animator anim;

    [SerializeField] GameObject maincam;

    void Start()
    {
        anim = GetComponent<Animator>();
        Time.timeScale = 0;
    }

    public void StartCamera()
    {
        anim.SetBool("StartCamera", true);
        Invoke("SetCamera", 0.5f);
        Time.timeScale = 1;
    }
    private void SetCamera()
    {
        maincam.GetComponent<CameraFollow>().enabled = true;
    }
}

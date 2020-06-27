using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMove : MonoBehaviour
{
    private Transform player;
    private Transform rat;

    [SerializeField] float speed;
    [SerializeField] private float maxDistance;
    [SerializeField] private float minDistance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rat = this.transform;
    }

    void Update()
    {
        Vector3 v3 = player.position - rat.position;
        v3.y = 0.0f;

        if (Vector3.Distance(player.position, rat.position) > maxDistance)
        {
            rat.position += rat.forward * speed * Time.deltaTime;
        }

        if (Vector3.Distance(player.position, rat.position) > minDistance)
        {
            rat.position -= rat.forward * speed * Time.deltaTime;
        }

        transform.LookAt(player);
    }

    public void StopMove()
    {
        Destroy(this.gameObject);
    }

    public void DebugRatSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;
    private Vector3 moveVector;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;

    }

    void LateUpdate()
    {
        moveVector = player.position + offset;

        moveVector.x = 0.48f;
        //moveVector.y = 2.93f;

        transform.position = moveVector;
    }


}

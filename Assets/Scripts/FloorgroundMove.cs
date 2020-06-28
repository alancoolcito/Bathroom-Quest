using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorgroundMove : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        this.transform.position = new Vector3(transform.position.x, player.transform.position.y - 4.55f, player.transform.position.z + 55);
    }
}

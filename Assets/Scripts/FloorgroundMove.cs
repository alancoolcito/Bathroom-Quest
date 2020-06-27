using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorgroundMove : MonoBehaviour
{
    private Transform player;
    [SerializeField] Transform floor;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        this.transform.position = new Vector3(transform.position.x, player.transform.position.y - 5, player.transform.position.z + 55);
    }
}

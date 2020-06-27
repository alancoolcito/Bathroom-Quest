using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    private GameObject player;
    public List <GameObject> rats;

    [SerializeField] Canvas winScreen;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //rats = GameObject.FindWithTag("Rats");
        //ratMove = rats.GetComponent<RatMove>();

    }

    void OnCollisionEnter(Collision other)
    {
        player.GetComponent<Player>().Victory();

        foreach (var rat in rats)
        {
            rat.GetComponent<RatMove>().StopMove();
        }

        winScreen.gameObject.SetActive(true);
    }
}

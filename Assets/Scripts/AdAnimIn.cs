using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdAnimIn : MonoBehaviour
{
    [SerializeField] Animator anim;
    void OnTriggerEnter(Collider other)
    {
        anim.SetBool("Active", true);
    }
    void OnTriggerExit(Collider other)
    {
        anim.SetBool("Active", false);
    }
}

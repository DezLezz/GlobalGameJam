using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
        {
            anim.SetBool("IsWalking", true);

        }
        else 
        {
            anim.SetBool("IsWalking", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("IsWalkingB", true);

        }
        else
        {
            anim.SetBool("IsWalkingB", false);
        }
    }
}

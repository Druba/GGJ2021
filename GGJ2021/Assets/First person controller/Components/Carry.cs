using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : MonoBehaviour
{

    public Animator animator;

    private bool isCarrying = false;

    void FixedUpdate()
    {
        if (animator) {
            animator.SetBool("Carrying", isCarrying);
        }
    }

    public void PickUp()
    {
        isCarrying = true;
    }

    public void Drop()
    {
        isCarrying = false;
    }

}

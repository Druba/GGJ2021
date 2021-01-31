using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform Destination;

    private bool IsPickedUp = false;
    private Transform originalTransformParent;

    void Start()
    {
        originalTransformParent = this.transform.parent;
    }

    void Update()
    {
        if (IsPickedUp) {
            this.transform.position = Destination.position;
        }
    }

    void OnMouseDown()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.parent = Destination.transform;
        IsPickedUp = true;
    }

    void OnMouseUp()
    {
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        this.transform.parent = originalTransformParent;
        IsPickedUp = false;
    }
}

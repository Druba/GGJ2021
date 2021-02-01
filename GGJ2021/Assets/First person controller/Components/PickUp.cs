using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Carry Destination;
    public float PickUpDistance = 2f;

    private bool IsPickedUp = false;
    private Transform originalTransformParent;

    void Start()
    {
        originalTransformParent = this.transform.parent;
    }

    void Update()
    {
        if (IsPickedUp)
        {
            this.transform.position = Destination.transform.position;
        }
    }

    void OnMouseDown()
    {
        float Distance = Vector3.Distance(Destination.transform.position, this.transform.position);
        if (Distance < PickUpDistance)
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.parent = Destination.transform;
            Destination.PickUp();
            IsPickedUp = true;
        }
    }

    void OnMouseUp()
    {
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        this.transform.parent = originalTransformParent;
        Destination.Drop();
        IsPickedUp = false;
    }
}

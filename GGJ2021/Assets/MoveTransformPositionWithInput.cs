using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransformPositionWithInput : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _turnSpeed = 30f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Time.deltaTime * _turnSpeed * Vector3.down);

        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Time.deltaTime * _turnSpeed * Vector3.up);

        if (Input.GetKey(KeyCode.D))
            transform.position += Time.deltaTime * _moveSpeed * transform.right;

        if (Input.GetKey(KeyCode.A))
            transform.position += Time.deltaTime * _moveSpeed * -transform.right; // negative right gives us left

        if (Input.GetKey(KeyCode.W))
            transform.position += Time.deltaTime * _moveSpeed * transform.forward;

        if (Input.GetKey(KeyCode.S))
            transform.position += Time.deltaTime * _moveSpeed * -transform.forward; // negative forward gives us backward

        if (Input.GetKey(KeyCode.Space))
            transform.position = new Vector3(0, 0.5f, 0);
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10;
    public float JumpForce = 8;

    Rigidbody rb;
    int layerMask;
    float rayDistance = 1.2f;

    public Vector3Variable forwardVec;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //transform.forward = rb.velocity.normalized;
        forwardVec.value = transform.forward;

        layerMask = 1 << 9;

        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) ||
             Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow)) & Grounded())
        {
            transform.forward = forwardVec.value;
            rb.velocity = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.Space) & Grounded())
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            Move();

        }

        


    }
    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);

    }
    void Move()
    {
        rb.velocity = new Vector3(-Input.GetAxis("Horizontal1") * speed, rb.velocity.y,
            Input.GetAxis("Vertical1") * speed);
        transform.forward = rb.velocity.normalized;
    }

    bool Grounded()
    {
        if (Physics.Raycast(transform.position, -transform.up, rayDistance, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.up * rayDistance);
    }
}

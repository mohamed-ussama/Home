using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10;
    public float JumpForce = 8;

    Rigidbody rb;
    int layerMask;
    float rayDistance = 1.2f;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        layerMask = 1 << 9;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            Move();
            Debug.Log(rb.velocity);
            Debug.Log(Input.GetAxis("Vertical"));
            Debug.Log(Input.GetAxis("Horizontal"));

        }

        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow)||
             Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow)) & Grounded())
        {
            rb.velocity = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.Space) & Grounded())
        {
            Jump();
        }


    }
    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);

    }
    void Move()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y,
            Input.GetAxisRaw("Vertical") * speed);
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

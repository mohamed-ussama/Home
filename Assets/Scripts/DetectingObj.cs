using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingObj : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Rigidbody _rigidbody;



    private void Start()
    {
        player = GetComponent<Player>();
       // _rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Throwable")
        {
            Debug.Log("Throwable Detecting");
            col.gameObject.transform.parent = player.Hand.transform;
            col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //_rigidbody = col.gameObject.GetComponent<Rigidbody>().disable

        }
        else if(col.gameObject.tag == "NonThrowable")
        {
            Debug.Log("NonThrowable Detecting");
            col.gameObject.transform.parent = gameObject.transform;
            col.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        }
        else if (col.gameObject.tag == "Ground")
        {
            Debug.Log("Ground Detecting");
            player.isGrounded = true;

        }
    }
}

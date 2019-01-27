using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItem : MonoBehaviour
{

    public float radius = 1f;
    public float power = 2;
    int layerMask;
    Transform handTransform;

    public BoolVariable holding;
    public Vector3Variable forwardDir;

    Transform obj;
    // Start is called before the first frame update
    void Start()
    {
        handTransform = GetComponent<Transform>();
        holding.value = false;
    }

    // Update is called once per frame
    void Update()
    {
        layerMask = 1 << 11;
        if (Input.GetKey(KeyCode.L))
        {
            CatchObj();
        }
        if (Input.GetKey(KeyCode.K))
        {
            Throw();
        }
    }

    public void CatchObj()
    {
        if (!holding.value)
        {
            Collider[] hitColliders = Physics.OverlapSphere(handTransform.position, radius, layerMask);

            if (hitColliders.Length == 1)
            {
                hitColliders[0].GetComponent<Rigidbody>().isKinematic = true;
                hitColliders[0].transform.parent = handTransform;
                holding.value = true;
            }
            else if (hitColliders.Length > 1)
            {

                for (int i = 0; i < hitColliders.Length && i + 1 != hitColliders.Length; i++)
                {
                    Debug.Log("awl "+i);
                    if (Vector3.Distance(hitColliders[i].transform.position, handTransform.position) >
                        Vector3.Distance(hitColliders[i + 1].transform.position, handTransform.position))
                    {
                        obj = hitColliders[i + 1].transform;
                    }
                    else
                    {
                        obj = hitColliders[i].transform;
                    }
                    Debug.Log(i);
                }
                Debug.Log("ahlan");
                obj.GetComponent<Rigidbody>().isKinematic = true;
                obj.parent = handTransform;
                holding.value = true;
            }
        }



    }
    public void Throw()
    {
        if (transform.childCount == 1)
        {
            obj = transform.GetChild(0);
            obj.parent = null;
            obj.GetComponent<Rigidbody>().isKinematic = false;
            obj.GetComponent<Rigidbody>().velocity=(forwardDir.value * power);
            holding.value = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}

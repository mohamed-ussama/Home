using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{

    float radius = .5f;
    int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        layerMask = 1 << 11;

    }

    public void CatchObj()
    {
        void ExplosionDamage(Vector3 center, float radius)
        {
            Collider[] hitColliders = Physics.OverlapSphere(center, radius , layerMask);
            int i = 0;
            while (i < hitColliders.Length)
            {
                hitColliders[i].SendMessage("AddDamage");
                i++;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}

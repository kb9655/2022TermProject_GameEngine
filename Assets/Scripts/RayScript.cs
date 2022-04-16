using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    private RaycastHit hit;
    public float MaxDistance = 15f;
    private Vector3 aim;
    public float aimY;

    void Update()
    {
        aim = transform.position;
        aim.y += aimY;
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.DrawRay(aim, transform.forward * MaxDistance, Color.red, 0.3f);
            
            if (Physics.Raycast(aim, transform.forward, out hit, MaxDistance))
            {
                if (hit.transform.GetComponent<MeshRenderer>() && hit.transform.GetComponent<CapsuleCollider>())
                    hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
}

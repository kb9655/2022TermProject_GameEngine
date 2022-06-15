using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_3 : MonoBehaviour
{
    public GameObject player;

    public bool cursorLock;
    
    public float offsetX = 0f;
    public float offsetY = -3f;
    public float offsetZ = 5f;
    
    private float xTurn = 0;
    private float yTurn = 0;
    public float turnSpeed = 3f;

    void Awake()
    {
        Cursor.visible = false;
        if (cursorLock)
            Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    { 
        xTurn += Input.GetAxis("Mouse X");
        yTurn += Input.GetAxis("Mouse Y");
    }

    void FixedUpdate()
    { 
        transform.rotation = Quaternion.Euler( yTurn * -1, xTurn * turnSpeed, 0);
    }
    
    void LateUpdate()
    {
        Vector3 reverseDistance = new Vector3(offsetX, offsetY, offsetZ); 
        transform.position = player.transform.position - transform.rotation * reverseDistance;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_3 : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab0;
   
    [SerializeField]
    private GameObject bulletPrefab1;
    
    [SerializeField]
    private GameObject FirePos;

    [SerializeField]
    private GameObject FireRot;
  
    private Camera mainCam;

    public static int flag;

    void Start()
    {
        mainCam = Camera.main;
        flag = 0;
    }

    private RaycastHit hit;
    public float MaxDistance = 15f;
    private Vector3 aim;
    public float aimY;
    private bool isFire;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (flag == 0)
            {
                var bullet = Instantiate(bulletPrefab0).GetComponent<Bullet_3>();
                //var direction = new Vector3(this.transform.forward.x, transform.position.y, hitResult.point.z) - transform.position;
                // bullet.transform.position = direction.normalized;
                bullet.Shoot(FirePos.transform.forward, FirePos.transform.position, FirePos.transform.rotation);
                isFire = true;
            }

            if (flag == 1)
            {
                var bullet = Instantiate(bulletPrefab1).GetComponent<Bullet_3>();
                //var direction = new Vector3(this.transform.forward.x, transform.position.y, hitResult.point.z) - transform.position;
                // bullet.transform.position = direction.normalized;
                bullet.Shoot(FirePos.transform.forward, FirePos.transform.position, FirePos.transform.rotation);
                isFire = true;
            }
            
            RaycastHit hitResult;
            //if (Physics.Raycast(mainCam.ScreenPointToRay(transform.forwar), out hitResult))
            //{
            //    var bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
            //    var direction = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            //   // bullet.transform.position = direction.normalized;
            //    bullet.Shoot(direction.normalized, FirePos.transform.position);
            //}

          
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter04 : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject FirePos;

    [SerializeField]
    private GameObject FireRot;
  
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
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
            RaycastHit hitResult;
            //if (Physics.Raycast(mainCam.ScreenPointToRay(transform.forwar), out hitResult))
            //{
            //    var bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
            //    var direction = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            //   // bullet.transform.position = direction.normalized;
            //    bullet.Shoot(direction.normalized, FirePos.transform.position);
            //}

                var bullet = Instantiate(bulletPrefab).GetComponent<Bullet04>();
                //var direction = new Vector3(this.transform.forward.x, transform.position.y, hitResult.point.z) - transform.position;
                // bullet.transform.position = direction.normalized;
                bullet.Shoot(FirePos.transform.forward, FirePos.transform.position, FirePos.transform.rotation);
            isFire = true;
        }
    }
}
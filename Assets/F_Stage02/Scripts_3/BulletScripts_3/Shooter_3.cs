using UnityEngine;

public class Shooter_3 : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab0;
   
    [SerializeField]
    private GameObject bulletPrefab1;

    [SerializeField] 
    private GameObject bulletPrefab2;
    
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
            else if (flag == 1)
            {
                var bullet = Instantiate(bulletPrefab1).GetComponent<Bullet_3>();
                //var direction = new Vector3(this.transform.forward.x, transform.position.y, hitResult.point.z) - transform.position;
                // bullet.transform.position = direction.normalized;
                bullet.Shoot(FirePos.transform.forward, FirePos.transform.position, FirePos.transform.rotation);
                isFire = true;
            }
            else if (flag == 2)
            {
                var bullet = Instantiate(bulletPrefab2).GetComponent<Bullet_3>();
                //var direction = new Vector3(this.transform.forward.x, transform.position.y, hitResult.point.z) - transform.position;
                // bullet.transform.position = direction.normalized;
                bullet.Shoot(FirePos.transform.forward, FirePos.transform.position, FirePos.transform.rotation);
                isFire = true;
            }
            

          
        }
    }
}

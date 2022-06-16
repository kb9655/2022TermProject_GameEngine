using UnityEngine;

public class Bullet_3 : MonoBehaviour
{
    private Vector3 direction;
    private Rigidbody rigid;

    [SerializeField]
    private GameObject colleffect;
   
    public void Shoot(Vector3 direction , Vector3 pos, Quaternion Rot)
    {
        rigid = GetComponent<Rigidbody>();
        this.transform.rotation = Rot;
        this.transform.position = pos;
        this.direction = direction;
        Invoke("DestroyBullet", 5f);
    }

    public void DestroyBullet()
    {
        ObjectPool_3.ReturnObject(this);
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Map")
        {
            GameObject obj = Instantiate(colleffect, transform.position, transform.rotation);
            DestroyBullet();
            gameObject.SetActive(false);
        }

        if (collision.transform.tag == "Monster")
        {
            GameObject obj = Instantiate(colleffect, transform.position, transform.rotation);
            Enemy_3 enemy = collision.gameObject.GetComponent<Enemy_3>();
            if (enemy.isAwake)
            {
                enemy.GetDamage(20);
            }

            DestroyBullet();
            gameObject.SetActive(false);
        }
    }


    void FixedUpdate()
    {
        rigid.AddForce(direction * 5.0f,ForceMode.Impulse);
    }
}

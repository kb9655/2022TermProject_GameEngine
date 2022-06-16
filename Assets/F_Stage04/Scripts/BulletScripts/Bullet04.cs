using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet04 : MonoBehaviour
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
        ObjectPool04.ReturnObject(this);
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
            Enemy04 enemy = collision.gameObject.GetComponent<Enemy04>();

            enemy.GetDamage(20);

            DestroyBullet();
            gameObject.SetActive(false);
        }
        
        if (collision.transform.tag == "RunMonster")
        {
            GameObject obj = Instantiate(colleffect, transform.position, transform.rotation);
            RunEnemy04 enemy04 = collision.gameObject.GetComponent<RunEnemy04>();

            enemy04.GetDamage(20);

            DestroyBullet();
            gameObject.SetActive(false);
        }
    }


    void FixedUpdate()
    {
        rigid.AddForce(direction * 5.0f,ForceMode.Impulse);
    }
}

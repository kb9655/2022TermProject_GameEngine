using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    private Rigidbody rigid;
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
        ObjectPool.ReturnObject(this);
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Map")
        {
            Debug.Log("Coll");
            DestroyBullet();
            gameObject.SetActive(false);
        }
    }


    void FixedUpdate()
    {
        rigid.AddForce(direction* 5.0f,ForceMode.Impulse);
    }
}

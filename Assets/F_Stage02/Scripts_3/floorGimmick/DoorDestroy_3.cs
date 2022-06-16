using UnityEngine;

public class DoorDestroy_3 : MonoBehaviour
{
    public int doorHealthy = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorHealthy <= 0)
        {
            Destroy(this.gameObject);
        }

       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            doorHealthy -= 20;
        }
        
    }
    
    public void GetDamage(int damage)
    {
        doorHealthy -= damage;
        if (doorHealthy < 0)
        {
          
                Soldier_3 s = GameObject.FindGameObjectWithTag("Player").GetComponent<Soldier_3>();
                s.setKey(true);
            
            Destroy(gameObject);

        }
    }

}

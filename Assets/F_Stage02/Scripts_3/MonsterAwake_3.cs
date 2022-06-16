using UnityEngine;

public class MonsterAwake_3 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject[] AwakeMonster;
    


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AwakeMonsters();
            this.gameObject.SetActive(false);
        }
    }

    private void AwakeMonsters()
    {
      for(int i = 0; i < AwakeMonster.Length; ++i)
        {
            Enemy enemy = AwakeMonster[i].GetComponent<Enemy>();
            enemy.isAwake = true;
            
        }
    }

}

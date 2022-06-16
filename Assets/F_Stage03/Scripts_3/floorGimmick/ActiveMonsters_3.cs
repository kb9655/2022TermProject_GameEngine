using UnityEngine;

public class ActiveMonsters_3 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] AwakeMonster;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ActiveMonsters();
        }
    }
    private void ActiveMonsters()
    {
        for(int i = 0; i < AwakeMonster.Length; ++i)
        {
            AwakeMonster[i].SetActive(true);
            //  Enemy_3 enemy = AwakeMonster[i].GetComponent<Enemy_3>();
           // enemy.isAwake = true;
        }
    }
}



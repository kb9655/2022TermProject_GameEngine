using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeMonsterLever_3 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] AwakeMonster;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AwakeMonsters();
        }
    }

    private void AwakeMonsters()
    {
        for(int i = 0; i < AwakeMonster.Length; ++i)
        {
            Enemy_3 enemy = AwakeMonster[i].GetComponent<Enemy_3>();
            enemy.isAwake = true;
        }
    }
}

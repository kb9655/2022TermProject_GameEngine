using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock02 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject LeftDoor;

    [SerializeField]
    private GameObject RightDoor;

    [SerializeField]
    private GameObject[] AwakeMonster;

    private bool flag = false;

    private float openPosR;
    private float openPosL;

    public void Open()
    {
        if (!flag)
        {
            openPosR = RightDoor.transform.position.z - 3.0f;
            openPosL = LeftDoor.transform.position.z + 3.0f;
            AwakeMonsters();

            
            flag = true;
        }
    }

    private void AwakeMonsters()
    {
      for(int i = 0; i < AwakeMonster.Length; ++i)
        {
            Enemy02 enemy = AwakeMonster[i].GetComponent<Enemy02>();
            enemy.isAwake = true;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag)
        {
            if(RightDoor.transform.position.z > openPosR)
                 RightDoor.transform.Translate(1 * Time.deltaTime, 0, 0);
            
            if (LeftDoor.transform.position.z < openPosL)
                LeftDoor.transform.Translate(-1 * Time.deltaTime, 0, 0);
            this.gameObject.transform.Translate(0, 10 * Time.deltaTime, 0);
            this.gameObject.transform.Rotate(Vector3.down * 500 * Time.deltaTime);
            
        }


    }
}

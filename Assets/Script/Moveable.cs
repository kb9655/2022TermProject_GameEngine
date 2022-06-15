using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   //Navmesh같은 기능을 사용할 때 필요함

public class Moveable : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    Transform target;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is caglled before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            agent.SetDestination(target.position);
        }
    }
}

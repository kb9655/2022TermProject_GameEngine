using UnityEngine;
using UnityEngine.AI;   //Navmesh���� ����� ����� �� �ʿ���

public class Moveable_3 : MonoBehaviour
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

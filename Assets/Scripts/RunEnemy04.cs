using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunEnemy04 : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;
    public bool isRun;
    public bool isKey;
    public Vector3 destination;
    
    [SerializeField]
    public Transform target;

    BoxCollider boxCollider;
    NavMeshAgent nav;
    Rigidbody rigid;
    Animator anim;

    public bool isAwake;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        Invoke("RunStart", 1);   
    }

    void RunStart()
    {
        isRun = true;
        anim.SetBool("isWalk", true);
    }

    void Update()
    {
        destination =  new Vector3(transform.position.x - target.position.x, 0f, transform.position.z - target.position.z).normalized;
        nav.SetDestination(transform.position + destination * 5f);
        if (isRun)
        {
            nav.SetDestination(transform.position + destination * 5f);
        }
    }

    public void GetDamage(int damage)
    {
        curHealth -= damage;
        if (curHealth < 0)
        {
            if (isKey)
            {
                Soldier04 s = GameObject.FindGameObjectWithTag("Player").GetComponent<Soldier04>();
                s.setKey(true);
            }
            Destroy(gameObject);

        }
    }

    void Targerting()
    {
        float targetRadious = 1.5f;
        float targetRange = 3f;

        RaycastHit[] rayHits =
            Physics.SphereCastAll(transform.position,
                                  targetRadious,
                                  transform.forward,
                                  targetRange,
                                  LayerMask.GetMask("Player"));
    }
    
    void FixedUpdate()
    {
        Targerting();
        FreezeVelocity();
    }

    void FreezeVelocity()
    {
        if(isRun)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }
    }
}

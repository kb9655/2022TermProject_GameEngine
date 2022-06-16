using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy5 : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;
    public bool isChase;
    public bool isAttack;
    public bool isKey = false;
    public BoxCollider meleeArea;
    [SerializeField]
    public Transform target;

    BoxCollider boxCollider;
    NavMeshAgent nav;
    Rigidbody rigid;
    Animator anim;

    public bool isAwake = false;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        Invoke("ChaseStart", 1);    //1초후에 동작
    }

    void ChaseStart()
    {
        isChase = true;
        anim.SetBool("isWalk", true);
    }
    // Update is called once per frame
    void Update()
    {
        if (isAwake)
        {
            nav.SetDestination(target.position);  //도착할 목표 위치 지정 함수
            if (isChase)
            {
                nav.SetDestination(target.position);
            }
        }
    }
    
    public void GetDamage(int damage)
    {
        curHealth -= damage;
        if (curHealth < 0)
        {
            if (isKey)
            {
                Soldier5 s = GameObject.FindGameObjectWithTag("Player").GetComponent<Soldier5>();
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

        if(rayHits.Length > 0 && !isAttack)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        anim.SetBool("isAttack", true);
        
        yield return new WaitForSeconds(0.2f);
        meleeArea.enabled = true;

        yield return new WaitForSeconds(1f);
        meleeArea.enabled = false;
        
        isChase = true;
        isAttack = false;
        anim.SetBool("isAttack", false);

    }
    void FixedUpdate()
    {
        Targerting();
        FreezeVelocity();
    }

    void FreezeVelocity()
    {
        if(isChase)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }
    }
    
}

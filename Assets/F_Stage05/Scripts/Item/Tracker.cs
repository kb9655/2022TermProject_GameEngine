using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tracker : MonoBehaviour
{
    [SerializeField]
    public Transform target1;
    NavMeshAgent nav1;
    Rigidbody rigid1;
    Animator anim1;
    public bool isChase;
    public bool isAwake;
    public bool isAttack;
    public int maxHealth = 100;
    public int curHealth = 100;
    public BoxCollider meleeArea1;

    private GameObject Labo;
    void Awake()
    {
        anim1 = GetComponentInChildren<Animator>();
        nav1 = GetComponent<NavMeshAgent>();
        Invoke("ChaseStart", 1);
    }

    void ChaseStart1()
    {
        isChase = true;
        anim1.SetBool("isWalk", true);
    }

    void Update()
    {
        if (isAwake)
        {
            nav1.SetDestination(target1.position);  //도착할 목표 위치 지정 함수
            if (isChase)
            {
                nav1.SetDestination(target1.position);
            }
        }
    }
    void ChickenTarget()
    {
         float targetRadious = 1.5f;
        float targetRange = 3f;

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position,
                              targetRadious,
                              transform.forward,
                              targetRange,
                              LayerMask.GetMask("ChickenMeat"));

        if (rayHits.Length > 0 && !isAttack)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        anim1.SetBool("isAttack", true);

        yield return new WaitForSeconds(0.2f);
        meleeArea1.enabled = true;

        yield return new WaitForSeconds(1f);
        meleeArea1.enabled = false;

        isChase = true;
        isAttack = false;
        anim1.SetBool("isAttack", false);

    }
    void ChaseStart()
    {
        isChase = true;
        anim1.SetBool("isWalk", true);
    }
    /*
    void FreezeVelocity()
    {
        if (isChase)
        {
            rigid1.velocity = Vector3.zero;
            rigid1.angularVelocity = Vector3.zero;
        }
    }
    */
    void FixedUpdate()
    {
        ChickenTarget();
        //FreezeVelocity();
    }

    void OnTriggerEnter(Collider other)
    {
        if(transform.gameObject.tag == "Lab")
        {
            Labo = other.gameObject;


        }
    }

}

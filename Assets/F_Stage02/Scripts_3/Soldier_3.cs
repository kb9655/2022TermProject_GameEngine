
using UnityEngine;

public class Soldier_3 : MonoBehaviour
{
    public float speed = 10f;
    public float jumpPower = 5f;

    public Camera mainCamera;

    private Rigidbody rigidbody;
    private Animator animator;

    private Vector3 heading;
    private Vector3 movement;
    private float horizontalMove;
    private float verticalMove;
    private bool isJumping;
    private bool isShooting;

    private float xTurn = 0;
    public float turnSpeed;
    private bool isKey = true;

    public GameObject point;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        point.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        // if(other.transform.tag == "Lock" && isKey)
        // {
        //     DoorLock_3 dl = other.gameObject.GetComponent<DoorLock_3>();
        //     dl.Open();
        //     setKey(false);
        // }
    }

    void Update()
    {
        xTurn += Input.GetAxis("Mouse X");

        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
            isJumping = true;

        if (Input.GetMouseButtonDown(0))
            isShooting = true;
        else if (Input.GetMouseButtonUp(0))
            isShooting = false;


        AnimationUpdate();
    }

    void FixedUpdate()
    {
        Turn();

        Run();
        Jump();
    }

    void AnimationUpdate()
    {
        if (horizontalMove == 0 && verticalMove == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }

        if (isShooting == false)
        {
            animator.SetBool("isShooting", false);
        }
        else
        {
            animator.SetBool("isShooting", true);
        }
    }

    private void Jump()
    {
        if (!isJumping)
            return;

        rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

        isJumping = false;
    }

    private void Run()
    {
        heading = transform.localRotation * Vector3.forward;
        heading.y = 0;
        heading = heading.normalized;

        movement = heading * Time.deltaTime * verticalMove * speed;
        movement += Quaternion.Euler(0, 90, 0) * heading * Time.deltaTime * Input.GetAxis("Horizontal") * speed;

        rigidbody.MovePosition(transform.position + movement);
    }

    void Turn()
    {
        transform.rotation = Quaternion.Euler(0, xTurn * turnSpeed, 0);
    }

    public void setKey(bool b_key)
    {
        isKey = b_key;
    }
    public bool getKey()
    {
        return isKey;
    }
}
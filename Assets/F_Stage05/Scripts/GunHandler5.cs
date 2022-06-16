using UnityEngine;

public class GunHandler5 : MonoBehaviour
{
    //--------------------------------
    public GunScript5 _gun; 
    Soldier5 _playerInput;


    void Start()
    {
        _playerInput = GetComponent<Soldier5>();
    }

    //--------------------------------
    void OnEnable()
    {
        _gun.gameObject.SetActive(true);
    } 

    void OnDisable()
    {
        _gun.gameObject.SetActive(false);
    } 

    //--------------------------------
    void Update()
    { 
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _gun.Fire();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            _gun.Reload();
        }
    }
}
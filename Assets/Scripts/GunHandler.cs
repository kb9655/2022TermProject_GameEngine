using UnityEngine;

public class GunHandler : MonoBehaviour
{
    //--------------------------------
    public GunScript _gun; 
    Soldier _playerInput;


    void Start()
    {
        _playerInput = GetComponent<Soldier>();
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
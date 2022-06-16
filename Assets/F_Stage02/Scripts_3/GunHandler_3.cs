using UnityEngine;

public class GunHandler_3 : MonoBehaviour
{
    //--------------------------------
    public GunScript_3 _gun; 
    Soldier_3 _playerInput;


    void Start()
    {
        _playerInput = GetComponent<Soldier_3>();
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
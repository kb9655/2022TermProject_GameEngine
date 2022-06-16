using UnityEditor;
using UnityEngine;

public class GunHandler04 : MonoBehaviour
{
    //--------------------------------
    public GunScript04 _gun;
    Soldier04 _playerInput;


    void Start()
    {
        _playerInput = GetComponent<Soldier04>();
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
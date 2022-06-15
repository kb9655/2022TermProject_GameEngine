using UnityEditor;
using UnityEngine;

public class GunHandler02 : MonoBehaviour
{
    //--------------------------------
    public GunScript02 _gun;
    Soldier02 _playerInput;


    void Start()
    {
        _playerInput = GetComponent<Soldier02>();
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
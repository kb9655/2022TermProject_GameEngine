using UnityEngine;

public class Siren_3 : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    public GameObject capsule;
    private bool isActive;

    private void Start()
    {
        light1.SetActive(false);
        light2.SetActive(false);
        isActive = false;
    }

    public void ActivateLight()
    {
        light1.SetActive(true);
        light2.SetActive(true);
        isActive = true;
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            capsule.transform.Rotate(new Vector3(0,0,10));
        }
      
    }
}

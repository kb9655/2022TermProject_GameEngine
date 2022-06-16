using UnityEngine;

public class Lever_3 : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    public bool active;
    
    public GameObject redButton;
    public GameObject greenButton;
    public GameObject siren;
    void Start()
    {
        active = false;
        
        redButton.SetActive(true);
        greenButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (active == false && collision.gameObject.tag == "Player")
        {
            Portal_3.activedLeverCount++;
            active = true;
            
            redButton.SetActive(false);
            greenButton.SetActive(true);
            siren.GetComponent<Siren_3>().ActivateLight();
        }
       
    }
}

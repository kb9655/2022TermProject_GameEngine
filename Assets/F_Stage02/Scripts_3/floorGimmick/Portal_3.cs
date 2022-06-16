using UnityEngine;

public class Portal_3 : MonoBehaviour
{
    public GameObject portal;
    private bool state;
    public static int activedLeverCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        state = false;
        portal.SetActive(state);
    }

    // Update is called once per frame
    void Update()
    {
        if (activedLeverCount>=3)
        {
            state = true;
            portal.SetActive(state);
        }
        
    }
}

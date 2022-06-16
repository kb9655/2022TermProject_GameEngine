using UnityEngine;

public class Flash_3 : MonoBehaviour
{
    public GameObject flash;
    public bool turn;
    
    // Start is called before the first frame update
    void Start()
    {
        turn = false;
        flash.SetActive(turn);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
            {
                if (turn == false)
                {
                    turn = true;
                    flash.SetActive(turn);
                }
                else
                {
                    turn = false;
                    flash.SetActive(turn);
                }
            }
            
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadScene(4);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler3 : MonoBehaviour
{
    public GameObject cardObject;

    private void Start()
    {
        cardObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Card3")
        {
            if (cardObject.activeSelf == false)
            {
                cardObject.SetActive(true);
            }
        }
    }
}

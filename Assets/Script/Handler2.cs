using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler2 : MonoBehaviour
{
    public GameObject cardObject;

    private void Start()
    {
        cardObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Card2")
        {
            if (cardObject.activeSelf == false)
            {
                cardObject.SetActive(true);
            }
        }
    }
}

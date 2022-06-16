using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler1 : MonoBehaviour
{
    public GameObject cardObject;

    private void Start()
    {
        cardObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Card1")
        {
            if (cardObject.activeSelf == false)
            {
                cardObject.SetActive(true);
            }
        }
    }
}

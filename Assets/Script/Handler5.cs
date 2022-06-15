using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler5 : MonoBehaviour
{
    public GameObject cardObject;

    private void Start()
    {
        cardObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Card5")
        {
            if (cardObject.activeSelf == false)
            {
                cardObject.SetActive(true);
            }
        }
    }
}

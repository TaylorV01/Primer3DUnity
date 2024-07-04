using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristals : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if(playerInventory != null )
        {
            playerInventory.CristalCollected();
            gameObject.SetActive(false);
        }
    }
}

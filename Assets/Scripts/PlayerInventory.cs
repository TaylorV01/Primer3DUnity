using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCristals {  get; set; }

    public UnityEvent<PlayerInventory> OnCristalCollected;

    public void CristalCollected()
    {
        NumberOfCristals++;
        OnCristalCollected.Invoke(this);
    }
}

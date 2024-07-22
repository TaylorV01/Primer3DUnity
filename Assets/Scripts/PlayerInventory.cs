using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class PlayerInventory : MonoBehaviourPunCallbacks
{
    public int NumberOfCristals {  get; set; }

    public UnityEvent<PlayerInventory> OnCristalCollected;

    public void CristalCollected()
    {
        if (photonView.IsMine)
        {
            NumberOfCristals++;
            OnCristalCollected.Invoke(this);
        }
    }
}

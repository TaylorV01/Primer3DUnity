using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject characterPrefab;  // GameObject type for the prefab
    public Transform spawnPoint;  // Renamed for clarity

    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else if (PhotonNetwork.InRoom)
        {
            SpawnPlayer();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        // Instantiate the GameObject prefab at the spawn point
        PhotonNetwork.Instantiate(characterPrefab.name, spawnPoint.position, spawnPoint.rotation);
    }
}


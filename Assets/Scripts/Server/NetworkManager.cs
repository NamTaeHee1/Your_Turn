using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public bool isConnected = false;
    void Awake() => PhotonNetwork.ConnectUsingSettings();

    private void Update()
    {
        if (PhotonNetwork.NetworkClientState.ToString().Equals("ConnectedToMasterServer"))
            isConnected = true;
    }
}

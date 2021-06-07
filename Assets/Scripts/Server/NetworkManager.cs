using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public bool isConnected = false;
    void Awake() => PhotonNetwork.ConnectUsingSettings();

    private void Update()
    {
        if (PhotonNetwork.NetworkClientState.ToString().Equals("ConnectedToMasterServer"))
            isConnected = true;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        
    }
}

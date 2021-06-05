using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    void Awake() => PhotonNetwork.ConnectUsingSettings();

    void Update() => Debug.Log(PhotonNetwork.NetworkClientState.ToString());
}

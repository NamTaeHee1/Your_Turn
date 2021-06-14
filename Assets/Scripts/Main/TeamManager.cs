using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class TeamManager : MonoBehaviourPunCallbacks
{
    [SerializeField] PhotonView PV;
    [SerializeField] TextMeshProUGUI[] PlayerList;

    public override void OnJoinedRoom()
    {
        PV.RPC("AddInPlayerList", RpcTarget.All, PhotonNetwork.NickName);
    }

    [PunRPC]
    void AddInPlayerList(string NickName)
    {
        for(int i = 0; i < PlayerList.Length; i++)
        {
            if(PlayerList[i].text == "")
            {
                PlayerList[i].text = NickName;
            }
        }
    }
}

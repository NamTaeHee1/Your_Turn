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
        for (int i = 0; i < PlayerList.Length; i++) PlayerList[i].text = "";
        TeamRenewal();
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
                break;
            }
        }
    }

    void TeamRenewal()
    {
        for (int i = 0; i < PhotonNetwork.CountOfPlayersInRooms; i++)
        {
            if (PhotonNetwork.PlayerList[i].NickName == "")
                break;
            PlayerList[i].text = PhotonNetwork.PlayerList[i].NickName;
        }
    }
}

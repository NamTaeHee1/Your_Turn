using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class TeamManager : MonoBehaviourPunCallbacks
{
    [SerializeField] PhotonView PV;
    [SerializeField] TextMeshProUGUI[] PlayerList;
    [SerializeField] Button ReadyOrStartButton;
    [SerializeField] TextMeshProUGUI ReadyOrStartButtonText;
    public bool isReady = false;

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
            ReadyOrStartButtonText.text = "시작";
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
                PlayerList[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[i].IsMasterClient ? "" : "준비중";
                break;
            }
        }
    }

    public void CheckReadyOrStartButton()
    {
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel("GameScene");
        else
            PV.RPC("CheckReadyButton", RpcTarget.All);
    }

    [PunRPC]
    void CheckReadyButton()
    {

    }

    void TeamRenewal()
    {
        for (int i = 0; i < PhotonNetwork.CountOfPlayersInRooms; i++)
        {
            if (PhotonNetwork.PlayerList[i].NickName == "")
                break;
            PlayerList[i].text = PhotonNetwork.PlayerList[i].NickName;
            PlayerList[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[i].IsMasterClient ? "" : "준비중";
        }
    }
}

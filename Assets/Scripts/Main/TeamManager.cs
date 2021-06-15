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
            ReadyOrStartButtonText.text = "����";
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
                PlayerList[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[i].IsMasterClient ? "" : "�غ���";
                break;
            }
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        TeamRenewal();
    }

    public void ClickReadyOrStartButton()
    {
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel("GameScene");
        else
        {
            isReady = !isReady;
            PV.RPC("CheckReadyButton", RpcTarget.All, ReadyOrStartButtonText.text == "�غ�" ? true : false);
            ReadyOrStartButtonText.text = isReady ? "�غ�" : "���";
        }
    }

    [PunRPC]
    void CheckReadyButton(bool isReady)
    {
        for(int i = 0; i < PlayerList.Length; i++)
        {
            if (PlayerList[i].text == PhotonNetwork.NickName)
            {
                PlayerList[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = isReady ? "�غ�Ϸ�" : "�غ���";
                PlayerList[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = isReady ? Color.green : Color.red;
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
            PlayerList[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[i].IsMasterClient ? "" : "�غ���";
        }
    }
}

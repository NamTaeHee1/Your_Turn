using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class TeamManager : MonoBehaviourPunCallbacks
{
    [SerializeField] PhotonView PV;
    GameObject CurrentPlayerTeamPanel;
    [SerializeField] GameObject[] RedTeamList;
    int RedTeamPlayerCount = 0;
    [SerializeField] GameObject[] BlueTeamList;
    int BlueTeamPlayerCount = 0;

    public override void OnJoinedRoom()
    {
        ActivationPanel();
    }

    public override void OnLeftRoom()
    {
        DisabledPanel(CurrentPlayerTeamPanel);
    }

    void ActivationPanel()
    {
        if (RedTeamPlayerCount >= RedTeamList.Length) {
            BlueTeamList[BlueTeamPlayerCount].transform.GetChild(0).gameObject.SetActive(true);
            BlueTeamList[BlueTeamPlayerCount].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = PhotonNetwork.NickName;
            BlueTeamList[BlueTeamPlayerCount].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "준비중";
            CurrentPlayerTeamPanel = BlueTeamList[BlueTeamPlayerCount];
        }
        else
        {
            RedTeamList[RedTeamPlayerCount].transform.GetChild(0).gameObject.SetActive(true);
            RedTeamList[RedTeamPlayerCount].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = PhotonNetwork.NickName;
            RedTeamList[RedTeamPlayerCount].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "준비중";
            CurrentPlayerTeamPanel = RedTeamList[RedTeamPlayerCount];
        }
    }

    void DisabledPanel(GameObject Panel)
    {
        Panel.transform.GetChild(0).gameObject.SetActive(false);
        Panel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
        Panel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
    }

    [PunRPC]
    void TeamRenewal()
    {
        
    }
}

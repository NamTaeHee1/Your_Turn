using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class TeamManager : MonoBehaviourPunCallbacks
{
    GameObject CurrentPlayerTeamPanel;
    [SerializeField] GameObject[] RedTeamList;
    int RedTeamPlayerCount = 0;
    [SerializeField] GameObject[] BlueTeamList;
    int BlueTeamPlayerCount = 0;

    public override void OnJoinedRoom()
    {
        if (RedTeamPlayerCount >= RedTeamList.Length)
            ActivationPanel(BlueTeamList[BlueTeamPlayerCount++]);
        else ActivationPanel(RedTeamList[RedTeamPlayerCount++]);
    }

    public override void OnLeftRoom()
    {
        
    }

    void ActivationPanel(GameObject Panel)
    {
        for (int i = 0; i < 3; i++)
            Panel.transform.GetChild(i).gameObject.SetActive(true);
        Panel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = PhotonNetwork.NickName;
        Panel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "�غ���";
        CurrentPlayerTeamPanel = Panel;
    }

    void DisabledPanel(GameObject Panel)
    {

    }

    void TeamListRenewal()
    {

    }

}

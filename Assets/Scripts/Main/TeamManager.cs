using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class TeamManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject[] RedTeamList;
    int RedTeamPlayerCount = 0;
    [SerializeField] GameObject[] BlueTeamList;
    int BlueTeamPlayerCount = 0;

    public override void OnJoinedRoom()
    {
        ActivationPanel(RedTeamList[RedTeamPlayerCount++]);
    }

    public override void OnLeftRoom()
    {

    }

    void ActivationPanel(GameObject Panel)
    {
        Panel.transform.GetChild(0).gameObject.SetActive(true);
        Panel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = PhotonNetwork.NickName;
        Panel.transform.GetChild(2).gameObject.SetActive(true);
    }

    void DisabledPanel(GameObject Panel)
    {

    }

    void TeamListRenewal()
    {

    }

}

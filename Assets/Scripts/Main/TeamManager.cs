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
    [SerializeField] GameObject[] BlueTeamList;
    int RedTeamListCount = 0;
    int BlueTeamListCount = 0;

    public override void OnJoinedRoom()
    {
        for(int i = 0; i < RedTeamList.Length; i++)
        {
            if (RedTeamList[i].transform.GetChild(0).gameObject.activeInHierarchy)
                continue;
            ActivationPanel(RedTeamList[i]);
            CurrentPlayerTeamPanel = RedTeamList[i];
            return;
        }
        for(int i = 0; i < BlueTeamList.Length; i++)
        {
            if (BlueTeamList[i].transform.GetChild(0).gameObject.activeInHierarchy)
                continue;
            ActivationPanel(BlueTeamList[i]);
            CurrentPlayerTeamPanel = BlueTeamList[i];
            return;
        }
    }

    public override void OnLeftRoom()
    {
        DisabledPanel(CurrentPlayerTeamPanel);
    }

    void ActivationPanel(GameObject Panel)
    {
        Panel.transform.GetChild(0).gameObject.SetActive(true);
        Panel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = PhotonNetwork.NickName;
        Panel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "¡ÿ∫Ò¡ﬂ";
    }

    void DisabledPanel(GameObject Panel)
    {
        Panel.transform.GetChild(0).gameObject.SetActive(false);
        Panel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
        Panel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
    }

}

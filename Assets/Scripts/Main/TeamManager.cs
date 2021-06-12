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
        if (RedTeamPlayerCount >= RedTeamList.Length)
            PV.RPC("ActivationPanel", RpcTarget.All, BlueTeamList[BlueTeamPlayerCount++]);
        else PV.RPC("ActivationPanel", RpcTarget.All, RedTeamList[RedTeamPlayerCount++]);
    }

    public override void OnLeftRoom()
    {
        PV.RPC("DisabledPanel", RpcTarget.All, CurrentPlayerTeamPanel);
    }

    [PunRPC]
    void ActivationPanel(GameObject Panel)
    {
        Panel.transform.GetChild(0).gameObject.SetActive(true);
        Panel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = PhotonNetwork.NickName;
        Panel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "¡ÿ∫Ò¡ﬂ";
        CurrentPlayerTeamPanel = Panel;
    }

    [PunRPC]
    void DisabledPanel(GameObject Panel)
    {
        Panel.transform.GetChild(0).gameObject.SetActive(false);
        Panel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
        Panel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
    }

    void TeamListRenewal()
    {

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class TeamManager : MonoBehaviourPunCallbacks
{
    [SerializeField] PhotonView PV;
    [SerializeField] GameObject[] RedTeamList;
    [SerializeField] GameObject[] BlueTeamList;
    List<string> RedTeamNickNameList;
    List<string> BlueTeamNickNameList;

    public override void OnJoinedRoom()
    {
        RedTeamNickNameList.Clear();
        BlueTeamNickNameList.Clear();
        RedTeamNickNameList.Add(PhotonNetwork.NickName);
    }

    private void Update()
    {
        for (int i = 0; i < RedTeamNickNameList.Count; i++)
            Debug.Log(RedTeamNickNameList[i] + " ");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

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

    [PunRPC]
    void TeamRenewal()
    {

    }
}

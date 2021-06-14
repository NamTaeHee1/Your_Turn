using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class TeamManager : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] PhotonView PV;
    [SerializeField] GameObject[] RedTeamList;
    [SerializeField] GameObject[] BlueTeamList;
    List<string> RedTeamNickNameList = new List<string>();
    List<string> BlueTeamNickNameList = new List<string>();

    public override void OnJoinedRoom()
    {
        TeamRenewal();
    }

    private void Update()
    {
        Debug.Log(PhotonNetwork.NickName);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        TeamRenewal();
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
        for(int i = 1; i <= PhotonNetwork.CountOfPlayersInRooms; i++)
            RedTeamList[i].transform.GetChild(0).gameObject.SetActive(true);
        /*        RedTeamNickNameList.Add(PhotonNetwork.NickName);
                for (int i = 0; i < RedTeamNickNameList.Count; i++)
                    Debug.Log(RedTeamNickNameList[i] + " ");*/
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }
}

using System.IO;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainSceneManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject LoadingPanel;

    [SerializeField] TextMeshProUGUI PlayerNickNameText;

    [SerializeField] Text LoadingText;

    string NickNameFilePath = @"D:\github\Your_Turn_Client\FileStream\NickName.txt";
    private void Awake()
    {
        PlayerNickNameText.text = File.ReadAllText(NickNameFilePath);
        NickNameControl.NickName = PlayerNickNameText.text;
        StartCoroutine(LoadingAnimation());
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() => PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby()
    {
        LoadingPanel.SetActive(false);
        PhotonNetwork.NickName = PlayerNickNameText.text;
        FindObjectOfType<RoomListManager>().MyList.Clear();
    }

    IEnumerator LoadingAnimation()
    {
        while (true)
        {
            string Loading = "·ÎµùÁß.";
            for (int i = 0; i < 3; i++)
            {
                LoadingText.text = Loading;
                Loading += '.';
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}

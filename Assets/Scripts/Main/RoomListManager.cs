using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomListManager : MonoBehaviourPunCallbacks
{
    public List<RoomInfo> MyList = new List<RoomInfo>();
    public Button[] CellButton;
    public Button PreviousButton, NextButton;
    int CurrentPage = 1, MaxPage, Multiple;
    [SerializeField] GameObject LoadingPanel;

    void Awake() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster() => PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby()
    {
        FindObjectOfType<RoomListManager>().MyList.Clear();
        LoadingPanel.SetActive(false);
    }

    public void MyListClick(int num)
    {
        if (num == -2)
            --CurrentPage;
        else if (num == -1)
            ++CurrentPage;
        else PhotonNetwork.JoinRoom(MyList[Multiple + num].Name);
        MyListRenewal();
    }


    public void CreateRoom() => PhotonNetwork.CreateRoom("TEST", new RoomOptions { MaxPlayers = 2 });

    void MyListRenewal()
    {
        MaxPage = (MyList.Count % CellButton.Length == 0) ? MyList.Count / CellButton.Length : MyList.Count / CellButton.Length + 1;

        PreviousButton.interactable = (CurrentPage <= 1) ? false : true;
        NextButton.interactable = (CurrentPage >= MaxPage) ? false : true;

        Multiple = (CurrentPage - 1) * CellButton.Length;
        for(int i = 0; i < CellButton.Length; i++)
        {
            CellButton[i].transform.GetChild(0).gameObject.SetActive((Multiple + i < MyList.Count) ? false : true);
            CellButton[i].transform.GetChild(1).GetComponent<Text>().text = (Multiple + i < MyList.Count) ? MyList[Multiple + i].Name : "";
            CellButton[i].transform.GetChild(2).GetComponent<Text>().text = (Multiple + i < MyList.Count) ? string.Format("ÆÀ´ç {0}¸í", (MyList[Multiple + i].MaxPlayers / 2).ToString()) : "";
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> RoomList)
    {
        int roomCount = RoomList.Count;
        for (int i = 0; i < roomCount; i++)
        {
            if (!RoomList[i].RemovedFromList)
            {
                if (!MyList.Contains(RoomList[i]))
                    MyList.Add(RoomList[i]);
                else
                    MyList[MyList.IndexOf(RoomList[i])] = RoomList[i];
            }
            else if (MyList.IndexOf(RoomList[i]) != -1)
                MyList.RemoveAt(MyList.IndexOf(RoomList[i]));
        }
        MyListRenewal();
    }
}

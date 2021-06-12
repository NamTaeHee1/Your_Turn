using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class RoomListManager : MonoBehaviourPunCallbacks
{
    public List<RoomInfo> MyList = new List<RoomInfo>();
    public Button[] CellButton;
    public GameObject[] CellButtonImage;
    public Button PreviousButton, NextButton;
    int CurrentPage = 1, MaxPage, Multiple;
    [SerializeField] GameObject LoadingPanel, MainPanel, RoomPanel, Player;
    [SerializeField] Text PeopleCountText;

    void Awake() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster() => PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby()
    {
        FindObjectOfType<RoomListManager>().MyList.Clear();
        LoadingPanel.SetActive(false);
    }

    private void Update()
    {
        Debug.Log("연결상태 : " + PhotonNetwork.NetworkClientState.ToString());
        Debug.Log("방 개수 : " + PhotonNetwork.CountOfRooms);
        if (PhotonNetwork.InRoom)
        {
            PeopleCountText.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
        }
    }

    public void MyListClick(int num)
    {
        if (num == -2)
            --CurrentPage;
        else if (num == -1)
            ++CurrentPage;
        else PhotonNetwork.JoinRoom(MyList[Multiple + num].Name);
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        MyListRenewal();
    }

    public void CreateRoom(string RoomTitle, int PersonNumber)
    {
        PhotonNetwork.CreateRoom(RoomTitle, new RoomOptions { MaxPlayers = byte.Parse((PersonNumber * 2).ToString()) });
    }

    public override void OnJoinedRoom()
    {
        RoomPanel.SetActive(true);
        Player.SetActive(false);
        MainPanel.SetActive(false);
    }

    void MyListRenewal()
    {
        MaxPage = (MyList.Count % CellButton.Length == 0) ? MyList.Count / CellButton.Length : MyList.Count / CellButton.Length + 1;

        PreviousButton.interactable = (CurrentPage <= 1) ? false : true;
        NextButton.interactable = (CurrentPage >= MaxPage) ? false : true;

        Multiple = (CurrentPage - 1) * CellButton.Length;
        for(int i = 0; i < CellButton.Length; i++)
        {
            CellButtonImage[i].SetActive((Multiple + i < MyList.Count) ? true : false);
            CellButton[i].interactable = (Multiple + i < MyList.Count) ? true : false;
            CellButton[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (Multiple + i < MyList.Count) ? MyList[Multiple + i].Name : "";
            CellButton[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = (Multiple + i < MyList.Count) ? string.Format("팀당 {0}명", (MyList[Multiple + i].MaxPlayers / 2).ToString()) : "";
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

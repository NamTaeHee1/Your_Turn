using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomListManager : MonoBehaviourPunCallbacks
{
    List<RoomInfo> MyList = new List<RoomInfo>();
    public Button[] CellButton;
    public Button PreviousButton, NextButton;
    int CurrentPage = 1, MaxPage, Multiple;

    public void MyListClick(int num)
    {
        if (num == -2)
            --CurrentPage;
        else if (num == -1)
            ++CurrentPage;
        else PhotonNetwork.JoinRoom(MyList[Multiple + num].Name);
    }

    void MyListRenewal()
    {
        MaxPage = (MyList.Count % CellButton.Length == 0) ? MyList.Count / CellButton.Length : MyList.Count / CellButton.Length + 1;

        PreviousButton.interactable = (CurrentPage <= 1) ? false : true;
        NextButton.interactable = (CurrentPage >= MaxPage) ? false : true;

        Multiple = (CurrentPage - 1) * CellButton.Length;
        for(int i = 0; i < CellButton.Length; i++)
        {
            CellButton[i].interactable = (Multiple + i < MyList.Count) ? false : true;
            CellButton[i].transform.GetChild(1).GetComponent<Text>().text = (Multiple + i < MyList.Count) ? MyList[Multiple + i].Name : "";
            CellButton[i].transform.GetChild(2).GetComponent<Text>().text = (Multiple + i < MyList.Count) ? string.Format("ÆÀ´ç {0}¸í", (MyList[Multiple + i].MaxPlayers / 2).ToString()) : "";
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        int roomCount = roomList.Count;
        for (int i = 0; i < roomCount; i++)
        {
            if (!roomList[i].RemovedFromList)
            {
                if (!MyList.Contains(roomList[i]))
                    MyList.Add(roomList[i]);
                else
                    MyList[MyList.IndexOf(roomList[i])] = roomList[i];
            }
            else if (MyList.IndexOf(roomList[i]) != -1)
                MyList.RemoveAt(MyList.IndexOf(roomList[i]));
        }
    }
}

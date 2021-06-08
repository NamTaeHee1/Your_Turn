using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainButtonManager : MonoBehaviour
{ 
    [SerializeField] GameObject AddRoomPanel, HidePanel;
    [SerializeField] TMP_InputField TitleInputText, PersonInputText;
    public void ClickQuitButton()
    {
        Application.Quit();
    }

    public void ClickAddRoom()
    {
        AddRoomPanel.SetActive(true);
        HidePanel.SetActive(true);
        TitleInputText.text = "";
        PersonInputText.text = "";
    }

    public void ClickAddRoomYes()
    {
        if (TitleInputText.text != "" && PersonInputText.text != "")
        {
            FindObjectOfType<RoomListManager>().CreateRoom(TitleInputText.text, PersonInputText.text);
            AddRoomPanel.SetActive(false);
            HidePanel.SetActive(false);
        }
    }

    public void ClickAddRoomNo()
    {
        AddRoomPanel.SetActive(false);
        HidePanel.SetActive(false);
    }

    public void ClickCharacter()
    {

    }
}

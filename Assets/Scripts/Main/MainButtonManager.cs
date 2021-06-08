using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainButtonManager : MonoBehaviour
{ 
    [SerializeField] GameObject AddRoomPanel, HidePanel;
    [SerializeField] TextMeshProUGUI TitleInputText, PersonInputText;
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

    }

    public void ClickAddRoomNo()
    {

    }

    public void ClickCharacter()
    {

    }
}

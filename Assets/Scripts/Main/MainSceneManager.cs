using System.IO;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PlayerNickNameText, LoadingText;
    [SerializeField] GameObject AddRoomPanel, HidePanel, MainPanel, RoomPanel;
    [SerializeField] TMP_InputField TitleInputText, PersonInputText;


    string NickNameFilePath = @"D:\github\Your_Turn_Client\FileStream\NickName.txt";
    private void Awake()
    {
        Screen.SetResolution(960, 540, false);
        PlayerNickNameText.text = File.ReadAllText(NickNameFilePath);
        StartCoroutine(LoadingAnimation());
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

    public void ClickQuitButton(string Panel)
    {
        if (Panel.Equals("Main"))
            Application.Quit();
        else
        {
            RoomPanel.SetActive(false);
            MainPanel.SetActive(true);
        }    
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
}

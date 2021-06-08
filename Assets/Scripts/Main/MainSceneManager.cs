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

    [SerializeField] TextMeshProUGUI PlayerNickNameText;

    [SerializeField] Text LoadingText;

    [SerializeField] GameObject AddRoomPanel;

    string NickNameFilePath = @"D:\github\Your_Turn_Client\FileStream\NickName.txt";
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
        PlayerNickNameText.text = File.ReadAllText(NickNameFilePath);
        NickNameControl.NickName = PlayerNickNameText.text;
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
}

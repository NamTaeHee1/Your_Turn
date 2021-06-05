using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainSceneManager : MonoBehaviour
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
    }

    private void Update()
    {
        LoadingPanel.SetActive(!FindObjectOfType<NetworkManager>().isConnected);
    }

    IEnumerator LoadingAnimation()
    {
        string Loading = "·ÎµùÁß.";
        for(int i = 0; i < 3; i++)
        {
            LoadingText.text = Loading;
            Loading += '.';
            yield return new WaitForSeconds(0.5f);
        }
    }
}

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PlayerNickNameText;
    string NickNameFilePath = @"D:\github\Your_Turn_Client\FileStream\NickName.txt";
    private void Awake()
    {
        PlayerNickNameText.text = File.ReadAllText(NickNameFilePath);
        NickNameControl.NickName = PlayerNickNameText.text;
    }
}

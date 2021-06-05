using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PlayerNickNameText;
    private void Start()
    {
        PlayerNickNameText.text = NickNameControl.NickName;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNickNameControl : MonoBehaviour
{
    [SerializeField]    private TextMeshProUGUI PlayerNickName;


    void Start()
    {
        PlayerNickName.text = TCPManager.PlayerNickName;
    }

}

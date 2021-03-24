using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNickNameControl : MonoBehaviour
{
    Transform PlayerTransform;
    [SerializeField]
    TextMeshProUGUI PlayerNickName;
    [SerializeField]
    int HeigthY = 10;

    private void Start()
    {
        PlayerTransform.GetComponent<Transform>();
    }

    void Update()
    {
        PlayerNickName.GetComponent<RectTransform>().anchoredPosition = PlayerTransform.GetComponent<Transform>().position;
    }
}

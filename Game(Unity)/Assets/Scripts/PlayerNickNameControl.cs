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


    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class ChatingManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI ChatInput;
    [SerializeField] private TextMeshProUGUI[] ChatText;
    [SerializeField] private PhotonView PV;
}

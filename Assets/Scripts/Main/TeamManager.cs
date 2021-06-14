using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class TeamManager : MonoBehaviourPunCallbacks
{
    [SerializeField] PhotonView PV;
    [SerializeField] TextMeshProUGUI[] PlayerList;
}

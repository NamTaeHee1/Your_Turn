using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class ChatingManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI ChatInput;
    [SerializeField] private TextMeshProUGUI[] ChatText;
    [SerializeField] private PhotonView PV;

    public override void OnJoinedRoom()
    {
        ChatInput.text = "";
        for (int i = 0; i < ChatText.Length; i++)
            ChatText[i].text = "";
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        ChatRPC("<color=yellow>" + newPlayer.NickName + "¥‘¿Ã ¬¸∞°«œºÃΩ¿¥œ¥Ÿ</color>");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        ChatRPC("<color=yellow>" + otherPlayer.NickName + "¥‘¿Ã ≈¿Â«œºÃΩ¿¥œ¥Ÿ</color>");
    }

    public void ClickSend()
    {
        PV.RPC("ChatRPC", RpcTarget.All, PhotonNetwork.NickName + " : " + ChatInput.text);
        ChatInput.text = "";
    }

    [PunRPC]
    void ChatRPC(string Message)
    {
        bool isInput = false;
        for(int i = 0; i < ChatText.Length; i++)
        {
            if(ChatText[i].text == "")
            {
                isInput = true;
                ChatText[i].text = Message;
                break;
            }
        }
        if (!isInput)
        {
            for (int i = 0; i < ChatText.Length; i++)
                ChatText[i - 1].text = ChatText[i].text;
            ChatText[ChatText.Length - 1].text = Message;
        }
    }
}

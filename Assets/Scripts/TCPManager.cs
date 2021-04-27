using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class TCPManager : MonoBehaviour
{
    TcpClient Client;
    string ServerIP = "127.0.0.1";
    const int PORT = 8000;
    byte[] ReceveBuffer = new byte[6];
    byte[] ReceveBuffer1 = new byte[6];
    NetworkStream Stream;
    public static string PlayerNickName = "";

    void Start() => CheckWpfReceive();

    void CheckWpfReceive()
    {
        Client = new TcpClient(ServerIP, PORT);
        Stream = Client.GetStream();
        Stream.Read(ReceveBuffer, 0, ReceveBuffer.Length);
        Stream.Read(ReceveBuffer1, 0, ReceveBuffer1.Length);
        string Message = Encoding.Default.GetString(ReceveBuffer);
        string Message1 = Encoding.Default.GetString(ReceveBuffer1);

        Debug.Log("Message : " + Message + " Message1 : " + Message1);

        for (int i = 0; i < int.Parse(Message1[0].ToString()); i++)
            PlayerNickName += Message[i];
    }

}
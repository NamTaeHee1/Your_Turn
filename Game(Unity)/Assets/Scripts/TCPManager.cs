using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class TCPManager : MonoBehaviour
{
    TcpClient Client;
    string serverIP = "127.0.0.1";
    const int PORT = 8000;
    byte[] ReceveBuffer;

    void Start()
    {
        CheckWpfReceive();
    }

    void CheckWpfReceive()
    {
        Client = new TcpClient(serverIP, PORT);
        NetworkStream Stream;
        Stream = Client.GetStream();

        ReceveBuffer = new byte[14];
        Stream.Read(ReceveBuffer, 0, ReceveBuffer.Length);
        string Message = Encoding.UTF8.GetString(ReceveBuffer, 0, ReceveBuffer.Length);
        Debug.Log(Message);
    }
}

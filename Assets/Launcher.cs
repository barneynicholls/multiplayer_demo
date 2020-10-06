using UnityEngine;
using Photon.Pun;
using System;

public class Launcher : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Connect();
    }

    public void Connect()
    {
        PhotonNetwork.GameVersion = "0.0.0";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Join();
        base.OnConnectedToMaster();
    }

    public override void OnJoinedRoom()
    {
        StartGame();
        base.OnJoinedRoom();
    }

    private void StartGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.LoadLevel("Level01");
        }
    }

    private void Join()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Create();
        base.OnJoinRandomFailed(returnCode, message);
    }

    private void Create()
    {
        PhotonNetwork.CreateRoom(string.Empty);
    }
}

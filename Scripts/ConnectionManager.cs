using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    public GameObject SuccessScene;
    public InputField RoomID;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected");
        SuccessScene.SetActive(true);
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("DisConnected " + cause);
    }

    public override void OnJoinedLobby()
    {
        print("Joined...");
    }

    public void onCreateRoomClick()
    {
        PhotonNetwork.CreateRoom(RoomID.text, new RoomOptions { MaxPlayers = 2 });
    }

    public void onJoinRoomClick()
    {
        PhotonNetwork.JoinRoom(RoomID.text);
    }

    public override void OnCreatedRoom()
    {
        print("Room Created");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("Room Create Failed");
    }

    public override void OnJoinedRoom()
    {
        print("Room Joined");
        print(PhotonNetwork.CurrentRoom.PlayerCount);

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.NickName = "0";
        }
        else
        {
            PhotonNetwork.NickName = "X";
        }

        PhotonNetwork.LoadLevel("Play");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("Room Not Joined");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

  

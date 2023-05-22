using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class Connecting : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField RoomName;

    [SerializeField] private ListItem itemPrefab;
    [SerializeField] private Transform content;

    private bool connect = false;
    // Start is called before the first frame update
    public void ExitApp()
    {
        PhotonNetwork.LeaveLobby();
        Application.Quit();
    }
    void Start()
    {
        if(!connect)
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.ConnectToRegion("ru");
        }
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        Debug.Log("Вы подключены");
        PhotonNetwork.JoinLobby();
        connect = true;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log(cause);
    }

    public void CreateRoomButton()
    {
        if (connect)
        {
            Click.iskrest = true;
            Click.endgame = false;
            GameController.isStep = false;
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 2;
            PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default);
            PhotonNetwork.LoadLevel("game_scene");
        }
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created" + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            ListItem listitem = Instantiate(itemPrefab, content);
            if (listitem != null)
            {
                listitem.SetInfo(info);
            }
        }
        base.OnRoomListUpdate(roomList);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("game_scene");
    }
}

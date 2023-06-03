using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;

    public GameObject battleButton;
    public GameObject cancelButton;

    private void Awake()
    {
        if (PhotonLobby.lobby == null)
            PhotonLobby.lobby = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {        
        this.battleButton.SetActive(true);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void OnBattleButtonClicked()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnCancelButtonClicked()
    {
        PhotonNetwork.LeaveRoom();
        this.cancelButton.SetActive(false);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Return code: " + returnCode + " " + message);
        CreateNewRoom();
    }



    private void CreateNewRoom()
    {
        int randomRoomNumber = Random.Range(0, 10000);
        string roomName = "Room " + randomRoomNumber;
        RoomOptions options = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 10,
        };

        PhotonNetwork.CreateRoom(roomName, options);
    }

    
}

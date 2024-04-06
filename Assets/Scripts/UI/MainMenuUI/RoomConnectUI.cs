using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomConnectUI : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField _roomName;

    [SerializeField]
    private GameObject _waitingRoomForHost;
    [SerializeField]
    private GameObject _waitingRoomForPlayers;
    [SerializeField]
    private GameObject _roomsMenu;

    public void OnClick_CreateRoom()
    {
        CreateRoom();
    }

    public void OnClick_ConnectToRoom()
    {
        PhotonNetwork.JoinRoom(_roomName.text.ToString());
        
        if (PhotonNetwork.InRoom)
        {
            _roomsMenu.SetActive(false);
            _waitingRoomForPlayers.SetActive(true);
        }
    }

    private void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        
        PhotonNetwork.CreateRoom(_roomName.text.ToString(), roomOptions, TypedLobby.Default);              
    }

    public override void OnJoinedRoom()
    {
        if(PhotonNetwork.InRoom)
           PhotonNetwork.AutomaticallySyncScene = true;

        if(PhotonNetwork.IsMasterClient)
        {
            _roomsMenu.SetActive(false);
            _waitingRoomForHost.SetActive(true);
        }
        else
        {
            _roomsMenu.SetActive(false);
            _waitingRoomForPlayers.SetActive(true);
        }

        Debug.Log($"Successfully join room: {PhotonNetwork.CurrentRoom.Name}");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogWarning($"Failed to create room: {message}");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogWarning($"Failed to join room: {message}");
    }
}

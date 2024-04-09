using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class LeaveRoomUI : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject _roomsMenu;
    [SerializeField]
    private GameObject _waitingRoomForCreator;
    [SerializeField]
    private GameObject _waitingRoomForPlayer;

    public void OnClick_LeaveRoom()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            _waitingRoomForCreator.SetActive(false);
            _roomsMenu.SetActive(true);
        }
        
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            _waitingRoomForPlayer.SetActive(false);
            _roomsMenu.SetActive(true);
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if(newMasterClient == PhotonNetwork.MasterClient) 
        {
            _waitingRoomForPlayer.SetActive(false);
            _roomsMenu.SetActive(true);
            PhotonNetwork.LeaveRoom();
        }
    }

}

using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Button _connectToRoomButton;

    private const int _maxConnectionAttemps = 3;
    private int _connectionAttempts = 0;

    private void Start()
    {
        PhotonNetwork.NickName = "Player" + (int)Random.Range(0, 1000);
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log($"Connected to Photon Master Server! (Region: {PhotonNetwork.CloudRegion})");
        
        if(PhotonNetwork.IsConnected)
        {
            _connectToRoomButton.interactable = true;
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        if(!PhotonNetwork.IsConnected)
        {
            _connectToRoomButton.interactable = false;
        }

        if (_connectionAttempts < _maxConnectionAttemps)
        {
            _connectionAttempts++;
            Debug.LogWarningFormat($"Disconnected from Photon Master Server due to: {cause}. Reconnecting attempt {_connectionAttempts}/{_maxConnectionAttemps}");
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.Log($"Failed to reconnect after {_connectionAttempts} attempts. Giving up.");
        }
    }
}

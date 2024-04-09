using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{     
    [Header("First Player:")]
    [SerializeField]
    private GameObject _firstPlayerPrefab;
    [SerializeField]
    private Transform _spawnPositionFirst;

    [Header("Second Player:")]
    [SerializeField]
    private GameObject _secondPlayerPrefab;
    [SerializeField]
    private Transform _spawnPositionSecond;
  
    private void Awake()
    {
        if (PhotonNetwork.IsConnected)
        {
            int playerID = PhotonNetwork.LocalPlayer.ActorNumber;

            if (playerID == 1)
            {
                PhotonNetwork.Instantiate(_firstPlayerPrefab.name, _spawnPositionFirst.position, Quaternion.identity);
            }
            else if (playerID == 2)
            {
                PhotonNetwork.Instantiate(_secondPlayerPrefab.name, _spawnPositionSecond.position, Quaternion.identity);
            }
        }
    }
}

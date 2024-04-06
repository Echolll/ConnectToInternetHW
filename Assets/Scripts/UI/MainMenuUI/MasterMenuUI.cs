using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class MasterMenuUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textPlayerCount;

    private void Update()
    {
        if(_textPlayerCount.gameObject.activeSelf == true)
        _textPlayerCount.text = $"Players: {PhotonNetwork.CurrentRoom.PlayerCount}/{PhotonNetwork.CurrentRoom.MaxPlayers}";
    }
}

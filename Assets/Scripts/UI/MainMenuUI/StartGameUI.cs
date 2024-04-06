using Photon.Pun;
using UnityEngine;

public class StartGameUI : MonoBehaviourPunCallbacks
{
   public void OnClick_StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }
}

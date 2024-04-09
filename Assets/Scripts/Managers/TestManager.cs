using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    [SerializeField]
    ArenaUI arenaUI;

    public const byte MoveUnitsToTargetPositionEventCode = 1;

    public override void OnEnable()
    {
        base.OnEnable();
        //photonView.RPC("EndGame", RpcTarget.All, false);
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    //[PunRPC]
    public void EndGame(bool win)
    {
        if(win == true)
        {
            arenaUI.OnWinGame();
        }
        else if(win  == false) 
        {
        
           arenaUI.OnLoseGame();
        }
    }

    public void SendWinnerInformation()
    {
        
    }

    public void OnEvent(EventData photonEvent)
    {
        
    }
}

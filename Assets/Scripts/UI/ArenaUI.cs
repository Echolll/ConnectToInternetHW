using Photon.Pun;
using UnityEngine;

public class ArenaUI : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject _winCanvas;
    [SerializeField]
    GameObject _loseCanvas;
   
    public void OnLoseGame()
    {
        _loseCanvas.SetActive(true);       
    }

    public void OnWinGame()
    { 
        _winCanvas.SetActive(true);
    }
}

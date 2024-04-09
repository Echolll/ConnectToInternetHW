using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour , IPunObservable
{
    Rigidbody rb;
    PhotonView _photonView;

    [SerializeField]
    private int _health = 100;

    private bool _isAlive = true;
    public bool IsAlive { get { return _isAlive; } }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        _photonView = GetComponent<PhotonView>();       
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       if(stream.IsWriting)
       {
            stream.SendNext(_health); 
       }
       else
       {
           _health = (int)stream.ReceiveNext();
       }
    }

    private void Update()
    {
        if (_health <= 0)
            DestroyPlayer();
    }

    public void GetDamage(int damage)
    {       
         _health -= damage;
    }

    private void DestroyPlayer()
    {
        _isAlive = false;
        rb.constraints = RigidbodyConstraints.None;
        gameObject.GetComponent<PlayerController>().enabled = false;
               
        if (_photonView.IsMine)
        {
            var obj = FindObjectOfType<ArenaUI>();
            obj.OnLoseGame();
            _photonView.RPC("SendAnother", RpcTarget.Others);
        }

    }

    [PunRPC]
    private void SendAnother()
    {
        var obj = FindObjectOfType<ArenaUI>();
        obj.OnWinGame();
        _photonView.RPC("EndGame", RpcTarget.MasterClient);
    }

    [PunRPC]
    private void EndGame()
    {
        StartCoroutine(BackToMenu());
    }    

    private IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(5f);
        PhotonNetwork.LoadLevel(0);
    }
}

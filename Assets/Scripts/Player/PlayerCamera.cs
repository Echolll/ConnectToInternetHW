using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Camera _playerCamera;

    PhotonView _photonView;

    public override void OnEnable()
    {
        base.OnEnable();
        _photonView = GetComponent<PhotonView>();      
        CameraEnable();
    }

    private void CameraEnable()
    {      
        if (_photonView.IsMine)
        {
            _playerCamera.enabled = true;
        }
        else
        {
            _playerCamera.enabled = false;
        }
    }
}

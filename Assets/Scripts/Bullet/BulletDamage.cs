using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private int _damage = 20;

    PhotonView photonView;

    private void OnEnable()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            var health = other.gameObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.GetDamage(_damage);
                if (photonView.IsMine)
                {
                    PhotonNetwork.Destroy(photonView.gameObject);
                }
            }
        }
    }       
}

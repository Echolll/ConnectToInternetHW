using Photon.Pun;
using System.Collections;
using UnityEngine;

public class BulletLifeTime : MonoBehaviourPunCallbacks
{
    float _lifeTime = 5f;

    public override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        if (photonView.IsMine)
        {
            PhotonNetwork.Destroy(photonView.gameObject);
        }
    }   
}

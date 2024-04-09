using Photon.Pun;
using UnityEngine;

public class PlayerShoot : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private Transform _startPos;
   
    public void ShootAction()
    {
        FireBullet();
    }

    private void FireBullet()
    {
        var obj = PhotonNetwork.Instantiate(_bulletPrefab.name, _startPos.position, Quaternion.identity);
        obj.GetComponent<Rigidbody>().AddForce(transform.forward * 25f, ForceMode.Impulse);
    }
}

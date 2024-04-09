using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _moveSpeed = 5f;
    private float _rotationSpeed = 40f;

    PlayerControls input;
    PlayerShoot _shoot;
    PhotonView photonView;
    Camera _camera;

    private void OnEnable()
    {
        photonView = GetComponent<PhotonView>();
        _shoot = GetComponent<PlayerShoot>();

        input = new PlayerControls();
        input.Enable();
        input.Shoot.Shoot.performed += callBackContext => PlayerShoot();
    }

    private void OnDisable()
    {
        input.Disable();
        input.Shoot.Shoot.performed -= callBackContext => PlayerShoot();
    }

    void Update()
    {
        if (photonView.IsMine) 
        {
            PlayerMoving();
            PlayerRotation();
        }
    }
    
    private void PlayerRotation()
    {
        var inputRotate = input.Moving.Rotate.ReadValue<float>();
        float rotateY = inputRotate * _rotationSpeed * Time.deltaTime;
        var rotateDirection = new Vector3(0,rotateY,0);

        transform.Rotate(rotateDirection);
    }

    private void PlayerMoving()
    {
        var inputMoveDirection = input.Moving.Move.ReadValue<Vector3>();

        float DirectionX = inputMoveDirection.x * _moveSpeed * Time.deltaTime;
        float DirectionZ = inputMoveDirection.z * _moveSpeed * Time.deltaTime;
        var moveDirection = new Vector3(DirectionX, 0, DirectionZ);

        transform.Translate(moveDirection);
    }

    private void PlayerShoot()
    {
        if (photonView.IsMine)
        {
            _shoot.ShootAction();
        }     
    }
}

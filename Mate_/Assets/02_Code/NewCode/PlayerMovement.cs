using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerData _playerData;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerData = GetComponent<PlayerData>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    public void Move()
    {
        Vector3 moveDirection = new Vector3(_playerInput._moveInputX, 0, 0);
        transform.Translate(moveDirection * _playerData._moveSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        if (_playerInput._jumpInput && _playerData._isGrounded)
        {
            _playerData._isGrounded = false;
            _rigidbody.AddForce(Vector3.up * _playerData._jumpPower, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _playerData._isGrounded = true;
        }
    }

}

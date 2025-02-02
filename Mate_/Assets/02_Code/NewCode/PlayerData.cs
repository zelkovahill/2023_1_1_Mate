using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("플레이어 키")]
    public KeyCode _lefgKey = KeyCode.A;
    public KeyCode _rightKey = KeyCode.D;
    public KeyCode _jumpKey = KeyCode.W;

    [Space(10)]

    [Header("플레이어 이동 속도")]
    public float _moveSpeed = 5.0f;
    public float _jumpPower = 10.0f;
    public bool _isGrounded = true;

    [Header("플레이어 카메라")]
    public Camera _playerCamera;

}

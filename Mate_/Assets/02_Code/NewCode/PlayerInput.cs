using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float _moveInputX;
    public bool _jumpInput;

    private void Update()
    {
        moveInput();
        jumpInput();
    }

    private void moveInput()
    {
        _moveInputX = Input.GetAxis("Horizontal");
    }

    private void jumpInput()
    {
        _jumpInput = Input.GetKeyDown(KeyCode.W);
    }
}

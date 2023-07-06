using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CustomInput moveInput = null;
    private Rigidbody2D rb;


    private Vector2 moveVector = Vector2.zero;
    [SerializeField]
    private float moveSpeed = 10f;

    private void Awake()
    {
        moveInput = PlayerInput.input;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        moveInput.Enable();
        moveInput.Player.Movement.performed += OnMovementPerformed;
        moveInput.Player.Movement.canceled += OnMovementStopped;
    }

    private void OnDisable()
    {
        moveInput.Disable();
        moveInput.Player.Movement.performed -= OnMovementPerformed;
        moveInput.Player.Movement.canceled -= OnMovementStopped;
    }


    private void FixedUpdate()
    {
        //Debug.Log(moveVector);
        rb.velocity = moveVector * moveSpeed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementStopped(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
}

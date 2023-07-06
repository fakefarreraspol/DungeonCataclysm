using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerShooter : MonoBehaviour
{
    // Start is called before the first frame update
    private CustomInput shootInput = null;

    private Vector2 shootVector = Vector2.zero;
    
    [SerializeField]
    private GameObject bullet;

    // Update is called once per frame
    private void Awake()
    {
        shootInput = PlayerInput.input;
    }

    private void OnEnable()
    {
        shootInput.Enable();
        shootInput.Player.Shoot.performed += OnShootInputPerformed;
        shootInput.Player.Shoot.canceled += OnShootInputCancelled;
    }
    private void OnDisable()
    {
        shootInput.Player.Shoot.performed -= OnShootInputPerformed;
        shootInput.Player.Shoot.canceled -= OnShootInputCancelled;
    }


    ////////////////////////////////////////


    //              UPDATE               //

    ////////////////////////////////////////
    private void FixedUpdate()
    {
        Debug.Log(shootVector);

        
        
    }

    private void OnShootInputPerformed(InputAction.CallbackContext value)
    {
        shootVector = value.ReadValue<Vector2>();
        GameObject test = Instantiate(bullet, transform.position, Quaternion.identity); 
        Rigidbody2D testRB = test.GetComponent<Rigidbody2D>();
        testRB.velocity = shootVector*30;

        Destroy(test, 2);
    }
    private void OnShootInputCancelled(InputAction.CallbackContext value)
    {
        shootVector = Vector2.zero;
    }
}

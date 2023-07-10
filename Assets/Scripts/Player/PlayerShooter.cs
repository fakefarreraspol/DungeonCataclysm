using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class PlayerShooter : MonoBehaviour
{
    // Start is called before the first frame update
    private CustomInput shootInput = null;

    private Vector2 shootVector = Vector2.zero;

    

    //Shooting
    [SerializeField]
    private GameObject bullet;
    private bool isPlayerShooting = false;
    private bool canPlayerShoot = true;
    [SerializeField]
    private float shootingROF;
    [SerializeField] private float projectileVelocity;


    [SerializeField] public float damage = 20;

    
    
    ///////////////////////////////////
    //////////////////////////////////
    
    public static Action OnDamageDone;





    private PlayerStats playerStats;

    // Update is called once per frame



    private void Awake()
    {
        shootInput = PlayerStats.input;
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnEnable()
    {
        shootInput.Enable();
        shootInput.Player.Shoot.performed += OnShootInputPerformed;
        shootInput.Player.Shoot.canceled += OnShootInputCancelled;

        OnDamageDone += DoDamage;
    }
    private void OnDisable()
    {
        shootInput.Player.Shoot.performed -= OnShootInputPerformed;
        shootInput.Player.Shoot.canceled -= OnShootInputCancelled;

        OnDamageDone -= DoDamage;
    }


    ////////////////////////////////////////


    //              UPDATE               //

    ////////////////////////////////////////
    private void FixedUpdate()
    {
        //Debug.Log(shootVector);
        damage += 1;

        if (isPlayerShooting && canPlayerShoot)
        {
            ShootBullet();
        }

    }

    private void OnShootInputPerformed(InputAction.CallbackContext value)
    {
        shootVector = value.ReadValue<Vector2>();
        isPlayerShooting = true;

    }
    private void OnShootInputCancelled(InputAction.CallbackContext value)
    {
        shootVector = Vector2.zero;

        isPlayerShooting = false;
    }




    private void ShootBullet()
    {
        GameObject test = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D testRB = test.GetComponent<Rigidbody2D>();
        testRB.velocity = shootVector * projectileVelocity;

        Destroy(test, 1);

        canPlayerShoot = false;
        Invoke("DelayBetweenBullets", shootingROF);
    }

    private void DelayBetweenBullets()
    {
        canPlayerShoot = true;
    }

    private void DoDamage()
    {
        
    }
}

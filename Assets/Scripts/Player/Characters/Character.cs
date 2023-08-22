using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;



public class Character : MonoBehaviour
{
    //// STATS OF THE CHARACTER ////
    private CustomInput userInput = null;
    [SerializeField] protected CharacterStats character;
    private int health;
    private float speed;
    private int damage;
    private float rateOfFire;
    private float cooldown;

    protected bool isPlayerAttacking = false;
    protected bool canPlayerAttack = true;
    // Update is called once per frame
    protected Vector2 attackVector = Vector2.zero;



    private Rigidbody2D characterRb;
    private Vector2 moveVector = Vector2.zero;



    private void Awake()
    {
        userInput = PlayerInput.input;
        userInput = PlayerInput.input;
        characterRb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        //Inizializing stats
        health = character.Health;
        speed = character.Speed;
        damage = character.Damage;
        rateOfFire = character.RateOfFire;
        cooldown = character.Cooldown;
    }

    private void OnEnable()
    {
        userInput.Enable();
        userInput.Player.Shoot.performed += OnAttackInputPerformed;
        userInput.Player.Shoot.canceled += OnAttackInputCancelled;


        userInput.Player.Movement.performed += OnMovementPerformed;
        userInput.Player.Movement.canceled += OnMovementStopped;
    }
    private void OnDisable()
    {
        userInput.Disable();
        userInput.Player.Shoot.performed -= OnAttackInputPerformed;
        userInput.Player.Shoot.canceled -= OnAttackInputCancelled;


        userInput.Player.Movement.performed -= OnMovementPerformed;
        userInput.Player.Movement.canceled -= OnMovementStopped;
    }


    protected virtual void FixedUpdate()
    {
        if (isPlayerAttacking && canPlayerAttack)
        {
            Attack();
            canPlayerAttack = false;
        }
        characterRb.velocity = moveVector * speed;
        
    }

    protected virtual void Attack()
    {
        Invoke("DelayBetweenAttacks", rateOfFire);

    }
    protected virtual void UseAbility()
    {

    }

    public virtual void ReceiveDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }


    protected void DelayBetweenAttacks()
    {
        canPlayerAttack = true;
    }

    private void OnAttackInputPerformed(InputAction.CallbackContext value)
    {
        attackVector = value.ReadValue<Vector2>();
        isPlayerAttacking = true;

    }
    private void OnAttackInputCancelled(InputAction.CallbackContext value)
    {
        attackVector = Vector2.zero;

        isPlayerAttacking = false;
    }

    public int GetCharacterDamage()
    {
        return damage;
    }
    public int GetCharacterLife()
    {
        return health;
    }














    //Movement
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
        PlayerAnimations.OnSpriteChanged(moveVector);
    }

    private void OnMovementStopped(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
        PlayerAnimations.OnSpriteChanged(moveVector);
    }
}

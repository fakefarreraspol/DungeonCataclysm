using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public int chHP;
    [SerializeField] private int maxHP;
    public int chDamage;



    [SerializeField] protected float attackingROF;
    protected bool isPlayerAttacking = false;
    protected bool canPlayerAttack = true;
    private CustomInput attackInput = null;
    // Update is called once per frame
    protected Vector2 attackVector = Vector2.zero;

    
    private void Awake()
    {
        attackInput = PlayerInput.input;
    }
    private void Start()
    {
        chHP = maxHP;
        
    }

    private void OnEnable()
    {
        attackInput.Enable();
        attackInput.Player.Shoot.performed += OnAttackInputPerformed;
        attackInput.Player.Shoot.canceled += OnAttackInputCancelled;

        
    }
    private void OnDisable()
    {
        attackInput.Player.Shoot.performed -= OnAttackInputPerformed;
        attackInput.Player.Shoot.canceled -= OnAttackInputCancelled;

        
    }


    protected virtual void FixedUpdate()
    {
        if (isPlayerAttacking && canPlayerAttack)
        {
            Attack();
            canPlayerAttack = false;
        }
    }

    protected virtual void Attack()
    {
        Invoke("DelayBetweenAttacks", attackingROF);

    }
    protected virtual void UseAbility()
    {

    }

    public virtual void ReceiveDamage(int damage)
    {
        chHP -= damage;
        if (chHP <= 0)
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
}

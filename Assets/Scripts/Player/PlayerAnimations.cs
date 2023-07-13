using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using System;

public class PlayerAnimations : MonoBehaviour
{
    private Sprite playerSprite;
    private SpriteRenderer sprRenderer;
    private Animator animator;

    public static Action<Vector2> OnSpriteChanged;

    private void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        OnSpriteChanged += ChangeSpriteDirection;
        OnSpriteChanged += ChangeAnimation;
    }
    private void OnDisable()
    {
        OnSpriteChanged -= ChangeSpriteDirection;
        OnSpriteChanged -= ChangeAnimation;
    }



    private void ChangeAnimation(Vector2 dir)
    {

        if (dir != Vector2.zero)
        {
            if (dir.y < 0 && dir.x == 0) animator.SetTrigger("walkDown"); 
            else if (dir.y > 0) animator.SetTrigger("walkUp"); 
            else animator.SetTrigger("walkH");
            
        }



        if (dir != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else animator.SetBool("isMoving", false);



    }

    private void ChangeSpriteDirection(Vector2 dir)
    {
        if (dir.x > 0)
            sprRenderer.flipX = false;

        else if (dir.x < 0) sprRenderer.flipX = true;
    }

}

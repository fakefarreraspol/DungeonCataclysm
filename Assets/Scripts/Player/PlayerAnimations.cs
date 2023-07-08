using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using System;

public class PlayerAnimations : MonoBehaviour
{
    private Sprite playerSprite;
    private SpriteRenderer sprRenderer;

    public static Action<Vector2> OnSpriteChanged;

    private void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        OnSpriteChanged += ChangeSpriteDirection;
    }
    private void OnDisable()
    {
        OnSpriteChanged -= ChangeSpriteDirection;
    }

    private void ChangeSpriteDirection(Vector2 dir)
    {
        if(dir.x > 0)
            sprRenderer.flipX = false;
        
        else if (dir.x < 0) sprRenderer.flipX = true;
    }

}

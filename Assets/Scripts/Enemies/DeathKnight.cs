using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathKnight : Enemy
{
    
    protected override void Introduction()
    {
        //base.Introduction();
        Debug.Log("hola sexo"); 
    }

    protected override void Attack()
    {
        base.Attack();
        
    }

    protected override void Animate()
    {
        base.Animate();

        

    }
}
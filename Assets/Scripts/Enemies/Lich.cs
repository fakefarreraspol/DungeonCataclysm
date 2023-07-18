using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lich : Enemy
{
    // Start is called before the first frame update
    [SerializeField] private GameObject fire;

    public float projectileVelocity;

    

    protected Vector2 attackingVector = Vector2.zero;
   protected override void Attack()
    {
        base.Attack();
        ShootArrow();
    }

    private void ShootArrow()
    {
        
        Quaternion ArrowRotation = Quaternion.LookRotation(Vector3.forward, attackingVector);


        GameObject test = Instantiate(fire, transform.position, ArrowRotation);
        Rigidbody2D testRB = test.GetComponent<Rigidbody2D>();
        testRB.velocity = attackingVector * projectileVelocity;

        Destroy(test, 1);

        
        //Invoke("DelayBetweenBullets", attackingROF);
    }

   

    protected override void Animate()
    {
        base.Animate();

        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Character
{
    [SerializeField] private GameObject arrow;
    public float projectileVelocity;


    protected override void Attack()
    {
        base.Attack();
        ShootArrow();
    }

    private void ShootArrow()
    {
        GameObject test = Instantiate(arrow, transform.position, Quaternion.identity);
        Rigidbody2D testRB = test.GetComponent<Rigidbody2D>();
        testRB.velocity = attackVector * projectileVelocity;

        Destroy(test, 1);

        
        //Invoke("DelayBetweenBullets", attackingROF);
    }
}

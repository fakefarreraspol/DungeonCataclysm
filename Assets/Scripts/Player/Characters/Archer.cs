using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Character
{
    [SerializeField] private GameObject arrow;
    public float projectileVelocity;

    [SerializeField] float offset;




    protected override void Attack()
    {
        base.Attack();
        ShootArrow();
    }

    private void ShootArrow()
    {

        Quaternion ArrowRotation = Quaternion.LookRotation(Vector3.forward, attackVector);
        Vector3 attackVector3 = new Vector3(attackVector.x, attackVector.y, 0);



        GameObject test = Instantiate(arrow, transform.position + (attackVector3.normalized * offset), ArrowRotation);
        Rigidbody2D testRB = test.GetComponent<Rigidbody2D>();
        testRB.velocity = attackVector * projectileVelocity;

        Destroy(test, 1);


        //Invoke("DelayBetweenBullets", attackingROF);
    }
}

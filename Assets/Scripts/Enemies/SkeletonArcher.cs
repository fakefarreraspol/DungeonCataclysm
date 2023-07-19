using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArcher : Enemy
{
    // Start is called before the first frame update
   [SerializeField] private GameObject fire;

    [SerializeField] private float projectileVelocity;



    protected Vector2 attackingVector = Vector2.zero;
    protected override void Attack()
    {
        attackingVector = ComputeVector(transform.position, targetPos.position).normalized;

        if (canAttack)
        {
            Quaternion FireballRotation = Quaternion.LookRotation(Vector3.forward, attackingVector);


            GameObject test = Instantiate(fire, transform.position, FireballRotation);
            Rigidbody2D testRB = test.GetComponent<Rigidbody2D>();
            testRB.velocity = attackingVector * projectileVelocity;

            Destroy(test, 1);




            canAttack = false;
            Invoke("DelayBetweenAttacks", enemyRateOfFire);
        }

    }





    protected override void Animate()
    {
        base.Animate();



    }
}

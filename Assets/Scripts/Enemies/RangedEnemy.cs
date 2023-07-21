using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [Header("Ranged Enemy Stats")]
    [SerializeField] protected float projectileVelocity;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected float projectileLifetime;


    protected override void Start()
    {
        attackDistance = chaseDistance;
        base.Start();
    }
    protected override void Decide()
    {
        Attack();

    }

    protected override void Attack()
    {
        if(canAttack) SpawnBullet(enemyTarget.position);

        base.Attack();
    }

    protected void SpawnBullet(Vector2 destPos)
    {
        Vector2 attackingVector = ComputeVector(transform.position, destPos).normalized;

        if (canAttack)
        {
            Quaternion FireballRotation = Quaternion.LookRotation(Vector3.forward, attackingVector);


            GameObject newBullet = Instantiate(bullet, transform.position, FireballRotation);
            Rigidbody2D newBulletRB = newBullet.GetComponent<Rigidbody2D>();
            newBulletRB.velocity = attackingVector * projectileVelocity;

            Destroy(newBullet, projectileLifetime);




            
            Invoke("DelayBetweenAttacks", rateOfFire);
        }
    }
}

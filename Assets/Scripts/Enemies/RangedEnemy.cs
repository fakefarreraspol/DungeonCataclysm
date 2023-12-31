using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangedEnemy : Enemy
{
    [Header("Ranged Enemy Stats")]
    protected float projectileVelocity;
    [SerializeField] protected GameObject bullet;
    protected float projectileLifetime;

    protected Transform firingPoint;


    protected override void Start()
    {
        projectileLifetime = enemyStats.EProjectileLifetime;
        projectileVelocity = enemyStats.EProjectileVelocity;


        firingPoint = gameObject.transform.Find("FiringPoint");
        base.Start();
    }
    protected override void Decide()
    {
       

    }

    protected override void Attack()
    {
        base.Attack();
    }

    protected void SpawnBullet(Vector2 startPos,Vector2 destPos)
    {
        Vector2 attackingVector = ComputeVector(startPos, destPos).normalized;

        Quaternion FireballRotation = Quaternion.LookRotation(Vector3.forward, attackingVector);


        GameObject newBullet = Instantiate(bullet, startPos, FireballRotation);
        Rigidbody2D newBulletRB = newBullet.GetComponent<Rigidbody2D>();
        newBulletRB.velocity = attackingVector * projectileVelocity;

        BoxCollider2D box = newBullet.AddComponent<BoxCollider2D>();
        box.isTrigger = true;
        newBullet.AddComponent<Projectile>().AddProjectileDamage(enDamage);



        Destroy(newBullet, projectileLifetime);





        Invoke("DelayBetweenAttacks", enRateOfFire);
    }
    protected virtual void FlipShootingPoint()
    {
        //if (enSprRenderer.flipX) attackingPoint.transform.position = (Vector2)transform.position + new Vector2 (-APOffset.x, -APOffset.y);
        //else attackingPoint.transform.position = (Vector2)transform.position + new Vector2 (APOffset.x, -APOffset.y);
    }
}

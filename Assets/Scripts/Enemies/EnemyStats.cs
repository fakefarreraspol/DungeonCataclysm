using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyStats : ScriptableObject
{
    [Header("Enemy Common Stats")]
    public string _enName;
    public int _enHealth;
    public int _enDamage;
    public float _enRateOfFire = 0.0f;
    public float _enSpeed = 0.0f;
    public float _enCooldown = 0.0f;
    public float _enChaseDistance = 0.0f;
    public float _enAttackDistance = 0.0f;

    public float _enNextWaypointDistance = 0.0f;
    
    [Header("Ranged Enemy Stats")]
    public float _enProjectileVelocity = 0.0f;
    public float _enProjectileLifetime = 0.0f;

    [Header("Melee Enemy Stats")]
    public float _enAttackArea = 0.0f;
    public float _enAttackRange = 0.0f;

    public string EName
    {
        get { return _enName; }
        set { _enName = value; }
    }
    public int EHealth
    {
        get { return _enHealth; }
        set { _enHealth = value; }
    }
    public int EDamage
    {
        get { return _enDamage; }
        set { _enDamage = value; }
    }
    public float ERateOfFire
    {
        get { return _enRateOfFire; }
        set { _enRateOfFire = value; }
    }
    public float ESpeed
    {
        get { return _enSpeed; }
        set { _enSpeed = value; }
    }
    public float ECooldown
    {
        get { return _enCooldown; }
        set { _enCooldown = value; }
    }
    public float EChaseDistance
    {
        get { return _enChaseDistance; }
        set { _enChaseDistance = value; }
    }
    public float EAttackDistance
    {
        get { return _enAttackDistance; }
        set { _enAttackDistance = value; }
    }
    public float ENextWaypointDistance
    {
        get { return _enNextWaypointDistance; }
        set { _enNextWaypointDistance = value; }
    }

    public float EProjectileLifetime
    {
        get { return _enProjectileLifetime; }
        set { _enProjectileLifetime = value; }
    }
    public float EProjectileVelocity
    {
        get { return _enProjectileVelocity; }
        set { _enProjectileVelocity = value; }
    }
    public float EAttackArea
    {
        get { return _enAttackArea; }
        set { _enAttackArea = value; }
    }
    public float EAttackRange
    {
        get { return _enAttackRange; }
        set { _enAttackRange = value; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyStats : ScriptableObject
{
    public string _name;
    public int _health;
    public int _damage;
    public float _rateOfFire;
    public float _speed;
    public float _cooldown;
    public float _chaseDistance;
    public float _attackDistance;
    

    public string EName
    {
        get { return _name; }
        set { _name = value; }
    }
    public int EHealth
    {
        get { return _health; }
        set { _health = value; }
    }
    public int EDamage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public float ERateOfFire
    {
        get { return _rateOfFire; }
        set { _rateOfFire = value; }
    }
    public float ESpeed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public float ECooldown
    {
        get { return _cooldown; }
        set { _cooldown = value; }
    }
    public float EChaseDistance
    {
        get { return _chaseDistance; }
        set { _chaseDistance = value; }
    }
    public float EAttackDistance
    {
        get { return _attackDistance; }
        set { _attackDistance = value; }
    }
    
}

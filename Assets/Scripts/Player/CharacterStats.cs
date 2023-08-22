using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterStats : ScriptableObject
{
    public int _health;
    public int _damage;
    public float _rateOfFire;
    public int _speed;
    public float _cooldown;
    public int _score;

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public float RateOfFire
    {
        get { return _rateOfFire; }
        set { _rateOfFire = value; }
    }
    public int Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public float Cooldown
    {
        get { return _cooldown; }
        set { _cooldown = value; }
    }
    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }


}

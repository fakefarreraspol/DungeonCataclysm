
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterStats : ScriptableObject
{
    [Header("Common Stats")]
    public int _health;
    public int _damage;
    public float _rateOfFire = 0.0f;
    public float _speed = 0.0f;
    public float _cooldown = 0.0f;
    public int _score;

    [Header("Ranged Stats")]
    public float _projectileVelocity = 0.0f;
    public float _projectileLifetime = 0.0f;
    
    [Header("Melee Stats")]
    public float _attackRange = 0.0f;

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
    public float Speed
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


using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public int speed;

    public void AddProjectileDamage(int entityDamage) { damage = entityDamage; }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<Character>().ReceiveDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

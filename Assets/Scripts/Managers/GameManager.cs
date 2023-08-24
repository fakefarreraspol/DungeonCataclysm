using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;

public class GameManager : MonoBehaviour
{
    public static Action<GameObject> OnEnemyKilled;
    private FadeUI deathUI;

    private Character player;


    List<GameObject> listOfEnemies = new List<GameObject>();

    private GameObject[] roomDoors;
    
    // Start is called before the first frame update

    private void Awake()
    {
        player = FindObjectOfType<Character>();
        

        roomDoors = GameObject.FindGameObjectsWithTag("Door");


        deathUI = FindObjectOfType<FadeUI>();
    }
    private void Start()
    {
        listOfEnemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));

    }
    private void OnEnable() { OnEnemyKilled += EnemyKilled; }
    
    private void OnDisable() { OnEnemyKilled -= EnemyKilled; }
    
        
    
    // Update is called once per frame
    private void Update()
    {
        if (player.GetCharacterLife() <= 0)
        {
            deathUI.DeathScreenTrigger();
        }
        Debug.Log(listOfEnemies.Count);
        

        if(AreEnemiesDead())
        {
            for (int i = 0; i < roomDoors.Length; i++)
            {
                roomDoors[i].GetComponent<Animator>().SetTrigger("OpenDoor");
                Destroy(roomDoors[i].GetComponent<BoxCollider2D>());
            }
        }
    }

    private void EnemyKilled(GameObject enemy)
    {
        if (listOfEnemies.Contains(enemy))
        {
            listOfEnemies.Remove(enemy);
        }

    }

    private bool AreEnemiesDead()
    {
        if (listOfEnemies.Count <= 0)
        {
            return true;
        }
        else return false;
    }
}

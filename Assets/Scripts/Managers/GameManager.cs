using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private FadeUI deathUI;

    private Character player;
    private Enemy[] enemies;


    
    // Start is called before the first frame update

    private void Awake()
    {
        player = FindObjectOfType<Character>();
        enemies = FindObjectsOfType<Enemy>();


        deathUI = FindObjectOfType<FadeUI>();
    }
    private void Start()
    {   
        

    }

    // Update is called once per frame
    private void Update()
    {
        if (player.GetCharacterDamage() <= 0)
        {
            deathUI.DeathScreenTrigger();
        }
    }
}

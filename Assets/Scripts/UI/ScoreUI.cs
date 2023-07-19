using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class ScoreUI : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI scoreText;
    public static Action<int> OnScoreChanged;
    
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        //scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnEnable()
    {
        OnScoreChanged += OnEnemyDefeated;
    }
    private void OnDisable()
    {
        OnScoreChanged -= OnEnemyDefeated;
    }

    private void OnEnemyDefeated(int enemies)
    {
        scoreText.text = enemies.ToString();
    }
    
}

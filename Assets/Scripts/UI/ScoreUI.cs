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
        OnScoreChanged += sex;
    }
    private void OnDisable()
    {
        OnScoreChanged -= sex;
    }

    private void sex(int sex)
    {
        scoreText.text = sex.ToString();
    }
    
}

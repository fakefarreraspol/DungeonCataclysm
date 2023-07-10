
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public static Action<int> OnScoreChanged;

    private void OnEnable()
    {
        OnScoreChanged += ChangeScore;
    }
    private void OnDisable()
    {
        OnScoreChanged -= ChangeScore;
    }

    private void ChangeScore(int newscore)
    {
        score += newscore;
        
        ScoreUI.OnScoreChanged(score);
    }
}

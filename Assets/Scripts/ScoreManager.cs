using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; 

    private int score = 0; 

    void Start()
    {
        UpdateScoreText(); 
    }

    public void AddScore(int amount)
    {
        score += amount; 
        UpdateScoreText(); 
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); 
    }
}

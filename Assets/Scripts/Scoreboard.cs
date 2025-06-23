using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField]private TMP_Text scoreboardUI;
    private int score = 0;

    private void Start()
    {
        if (scoreboardUI == null)
        {
            Debug.LogError("Scoreboard UI Text is not assigned in the inspector.");
        }
        else
        {
            scoreboardUI.text = score.ToString();
        }
    }
    public void IncreaseScore(int points)
    {
        score += points;
        scoreboardUI.text = score.ToString();
    }
}

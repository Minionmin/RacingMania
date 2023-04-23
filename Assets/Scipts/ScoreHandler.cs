using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private float ScoreMultiplier = 1f;

    public const string HighScoreKey = "HighScore";
    private float Score = 0;

    void Update()
    {
        Score += Time.deltaTime * ScoreMultiplier;

        ScoreText.text = Mathf.FloorToInt(Score).ToString();
    }

    private void OnDestroy()
    {
        int CurrentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if(Score > CurrentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(Score));
        }
    }

}

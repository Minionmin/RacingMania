using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HighScoreText;
    [SerializeField] private TextMeshProUGUI EnergyText;
    [SerializeField] private int MaxEnergy;
    [SerializeField] private int EnergyRechargeDuration;
    [SerializeField] private AndroidNotificationHandler androidNotificationHandler;
    [SerializeField] private IOSNotificationHandler iosNotificationHandler;

    private int Energy;

    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";

    private void Start()
    {
        int HighScore = PlayerPrefs.GetInt(ScoreHandler.HighScoreKey, 0);

        HighScoreText.text = $"High Score: {HighScore}";

        Energy = PlayerPrefs.GetInt(EnergyKey, MaxEnergy);

        if(Energy == 0)
        {
            string EnergyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);

            if(EnergyReadyString == string.Empty){return;}

            DateTime EnergyReady = DateTime.Parse(EnergyReadyString);
            if(DateTime.Now > EnergyReady)
            {
                Energy = MaxEnergy;
                PlayerPrefs.SetInt(EnergyKey, Energy);
            }
        }

        EnergyText.text = $"Play ({Energy})";
    }

    public void Play()
    {
        if (Energy < 1) { return; }

        Energy--;
        PlayerPrefs.SetInt(EnergyKey, Energy);
        
        if(Energy == 0)
        {
            DateTime EnergyReady = DateTime.Now.AddMinutes(EnergyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, EnergyReady.ToString());
#if UNITY_ANDROID
            androidNotificationHandler.ScheduleNotification(EnergyReady);
#elif UNITY_IOS
            iosNotificationHandler.ScheduleNotification(EnergyRechargeDuration);
#endif
        }

        SceneManager.LoadScene(1);
    }
}

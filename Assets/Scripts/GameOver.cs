using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI roundsPlayedText;

    public SceneFader sceneFader;

    public string menuSceneName = "MainMenu";

    private void OnEnable()
    {
        roundsPlayedText.text = PlayerStats.RoundsPlayed.ToString();
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}

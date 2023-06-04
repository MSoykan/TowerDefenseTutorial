using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI roundsPlayedText;

    private void OnEnable()
    {
        roundsPlayedText.text = PlayerStats.RoundsPlayed.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        Debug.Log("Go to menu. TODO implement menu");
    }
}

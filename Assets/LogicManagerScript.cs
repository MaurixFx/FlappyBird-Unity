using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text recordScoreText;
    public GameObject gameOverScreen;
    public bool isGameActive = true;
    private int scoreRecord = 0;
    public MusicManager musicManager;

    void Start()
    {
        scoreRecord = PlayerPrefs.GetInt("scoreRecord");
        recordScoreText.text = $"RECORD: {scoreRecord}";

        // FindGameObjectWithTag helps to find gameobject with tag
        musicManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<MusicManager>();

        musicManager.ResumeMusic();
    }

    // Allow us to execute this function from unity to test if it works
    // [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        // Load the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        musicManager.ResumeMusic();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void gameOver()
    {
        if (playerScore > scoreRecord)
        {
            PlayerPrefs.SetInt("scoreRecord", playerScore);
        }

        isGameActive = false;
        gameOverScreen.SetActive(true); // Makes visible the game over screen
        musicManager.PauseMusic();
    }
}

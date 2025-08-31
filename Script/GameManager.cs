using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject restartPanel;

    private bool isPaused = false;

    public static GameManager instance;

    private int score = 0;
    private int highScore = 0;

    public TextMeshProUGUI scoreText;       // In-game score text (top corner)
    public TextMeshProUGUI finalScoreText;  // On RestartPanel: "Score: X"
    public TextMeshProUGUI highScoreText;   // On RestartPanel: "High Score: Y"

    void Awake()
    {
        instance = this;

        // Load saved high score
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit(); // Works in build
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        // Stop game
        Time.timeScale = 0f;

        // Save High Score
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        // Show Restart Panel with both scores
        restartPanel.SetActive(true);
        finalScoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

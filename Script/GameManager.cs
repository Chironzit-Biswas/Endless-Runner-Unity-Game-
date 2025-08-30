using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Assign in Inspector
    private bool isPaused = false;


    public static GameManager instance;
    private int score = 0;
    public TextMeshProUGUI scoreText;


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
        Time.timeScale = 0f; // Freeze game
        pauseMenuUI.SetActive(true); // Show menu
        isPaused = true;
        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume game
        pauseMenuUI.SetActive(false); // Hide menu
        isPaused = false;
        Debug.Log("Game Resumed");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit(); // Works in build, not in editor
    }

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text =score.ToString();
    }



}

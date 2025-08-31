using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class UIMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public VisualElement Menu;
    public Button StartButton;
    public Button OptionButton;
    public Button ExitButton;

    void Start()
    {
        
        var root = GetComponent<UIDocument>().rootVisualElement;
        Menu = root.Q<VisualElement>("Menu");
        StartButton = root.Q<Button>("StartButton");
        OptionButton = root.Q<Button>("OptionButton");
        ExitButton = root.Q<Button>("ExitButton");
        StartButton.clicked += OnStartButtonClicked;
        OptionButton.clicked += OnOptionButtonClicked;
        ExitButton.clicked += OnExitButtonClicked;
    }

    private void OnExitButtonClicked()
    {
        Debug.Log("Exit Button Clicked");
        // Add logic to exit the game
        Application.Quit();
    }

    private void OnOptionButtonClicked()
    {
        throw new NotImplementedException();
    }

    private void OnStartButtonClicked()
    {

        Menu.style.display = DisplayStyle.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Debug.Log("Start Button Clicked");

    }

  
}

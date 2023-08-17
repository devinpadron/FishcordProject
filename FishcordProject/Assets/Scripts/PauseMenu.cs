using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private bool isPaused = false;

    private void Update()
    {
        // Check for the Escape key input to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f; // Pause the game by setting time scale to 0
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f; // Resume the game by setting time scale back to 1
        }
    }

    public void Resume() //still working on this but the Main Menu one was the one i wanted to try and change the most
    {
        Time.timeScale = 1f;
    }

    public void MainMenu(int SceneID)
    {
        SceneManager.LoadScene(SceneID); // Load the main menu with build index 0 (maybe?)
    }
}

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
            //I added these 2 lines per statement.
            // What the problem was before was the cursor was never unlocked. You were just seeing Unity unlock ur cursor from the game itself.
            // Adding this allows the buttons to be pressed, and the functions to run.

            //I also changed the organization of the scene slightly.
            // It was pointless to have the Pausemenu AND the menu manager have the script.
            // The manager should be the only thing containing the script, pointing to the pausemenu item.
            // This way the script isnt called twice by mistake. I put the pausemenu item inside of the MenuManager item for organization purposes.
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f; // Pause the game by setting time scale to 0
        }
        else
        {
            pauseMenu.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f; // Resume the game by setting time scale back to 1
        }
    }

    public void MainMenu(int SceneID)
    {
        SceneManager.LoadScene(SceneID); // Load the main menu with build index 0 (maybe?)

        //This is correct. But when you return from the mainmenu timescale is still set to 0.
        // You would have to include this in the mainmenu script to make sure it is always set to 1 when you click Play
    }
}

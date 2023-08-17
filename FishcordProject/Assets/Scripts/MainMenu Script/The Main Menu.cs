using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
	public void MoveToPlay(int sceneID)
	{
		SceneManager.LoadScene(sceneID);

		// I added these 3 lines to make sure the game always is unpaused when you hit play.
		Time.timeScale = 1f;

		// These are done automatically but I left them here for better readability
		Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
}

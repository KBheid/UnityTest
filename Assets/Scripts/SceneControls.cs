using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControls : MonoBehaviour
{
	public void StopScene()
	{
		Application.Quit();
	}

	public void ReloadScene()
	{
		int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneBuildIndex);
	}
}

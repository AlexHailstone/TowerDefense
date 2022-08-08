using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public string levelToLoad = "Level01";
	public string levelSelector = "LevelSelect";
	public SceneFader sceneFader;


	public void Play()
	{
		sceneFader.FadeTo(levelSelector);

	}

	public void LevelSelector()
	{
		sceneFader.FadeTo(levelSelector);

	}

	public void Quit()
	{
		Debug.Log("Quitting...");
		Application.Quit();
	}


}

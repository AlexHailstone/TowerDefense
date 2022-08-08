using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public TextMeshProUGUI roundsTxt;
	public SceneFader scenefader;
	public string menuSceneName = "MainMenu";


	private void OnEnable()
	{
		roundsTxt.text = PlayerStats.rounds.ToString();

	}


	public void Retry()
	{
		//this pulls in the current scene, grabs that index and then reloads the current scene.
		scenefader.FadeTo(SceneManager.GetActiveScene().name);

	}


	public void Menu()
	{
		scenefader.FadeTo(menuSceneName);
	}
}

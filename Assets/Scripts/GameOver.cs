using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public TextMeshProUGUI roundsTxt;


	private void OnEnable()
	{
		roundsTxt.text = PlayerStats.rounds.ToString();

	}


	public void Retry()
	{
		//this pulls in the current scene, grabs that index and then reloads the current scene.
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}


	public void Menu()
	{
		Debug.Log("Go to Menu");

	}
}

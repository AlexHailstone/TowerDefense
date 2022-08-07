using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    private bool gameEnded = false;
    void Update()
    {
        if (gameEnded)
            return;

        if (PlayerStats.playerLives <= 0)
		{
            EndGame();
		}


    }


    void EndGame()
	{
        gameEnded = true;
        Debug.Log("Game Over!");
            //this is where we can add a reset or prompts or anything.
	}
}

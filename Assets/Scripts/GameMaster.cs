using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject gameOverUI;
    public static bool gameIsOver;
   


	private void Start()
	{
        gameIsOver = false;
	}


	void Update()
    {
        if (gameIsOver)
            return;

        if (PlayerStats.playerLives <= 0)
		{
            EndGame();
		}



			
    }


    void EndGame()
	{
        gameIsOver = true;
        Debug.Log("Game Over!");
        gameOverUI.SetActive(true);
            //this is where we can add a reset or prompts or anything.
	}
}

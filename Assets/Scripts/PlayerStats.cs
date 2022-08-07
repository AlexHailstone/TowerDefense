using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

	public static int Money;
	public static int playerLives;
	public int startMoney = 400;
	public int startLives = 20;
	public static int rounds;


	private void Start()
	{
		rounds = 0;
		Money = startMoney;
		playerLives = startLives;
	}




}

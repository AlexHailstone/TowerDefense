using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	

	[Header("Enemy Properties")]
	public float startSpeed = 10f;
	public float health = 100;
	public int valueOfEnemey = 50;
	public GameObject onDeathAnimation;

	[HideInInspector]
	public float movementSpeed;

	private void Start()
	{
		movementSpeed = startSpeed;
	}

	public void TakeDamage(float amount)
	{
		health -= amount;

		if (health <= 0)
		{
			Die();

		}
	}

	public void Slow(float pct)
	{
		movementSpeed = startSpeed * (1f - pct);
	}


	void Die()
	{
		GameObject effect = (GameObject)Instantiate(onDeathAnimation, transform.position, Quaternion.identity);
		PlayerStats.Money += valueOfEnemey;
		Destroy(gameObject);
		Destroy(effect, 5f);
	}

	}

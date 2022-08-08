using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
	

	[Header("Enemy Properties")]
	public float startSpeed = 10f;
	public float startHealth = 100f;

	public int valueOfEnemey = 50;
	public GameObject onDeathAnimation;
	public Image healthBar;
	[HideInInspector]
	public float movementSpeed;
	private float health;


	private void Start()
	{
		movementSpeed = startSpeed;
		health = startHealth;
	}

	public void TakeDamage(float amount)
	{
		health -= amount;

		healthBar.fillAmount = health / startHealth;

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

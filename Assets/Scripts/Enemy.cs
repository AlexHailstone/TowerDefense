using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public float movementSpeed = 10f;
	public int health = 100;
	public int valueOfEnemey = 50;
	public GameObject onDeathAnimation;

	private Transform target;
	private int wavepointIndex = 0;

	private void Start()
	{
		target = Waypoints.points[0];

	}

	public void TakeDamage(int amount)
	{
		health -= amount;

		if (health <= 0)
		{
			Die();

		}
	}

	void Die()
	{
		GameObject effect = (GameObject)Instantiate(onDeathAnimation, transform.position, Quaternion.identity);
		PlayerStats.Money += valueOfEnemey;
		Destroy(gameObject);
		Destroy(effect, 5f);
	}


	private void Update()
	{
		//get the pointing direction
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * movementSpeed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.2f)
		{
			GetNextWaypoint();
		}
	}
	void GetNextWaypoint()
		{
			if (wavepointIndex >= Waypoints.points.Length - 1)
			{
				EndPath();
				return;
			}
			wavepointIndex++;
			target = Waypoints.points[wavepointIndex];
		}


	void EndPath()
	{

		Debug.Log("Take Damage!");
		Destroy(gameObject);
		PlayerStats.playerLives--;
	}

	}

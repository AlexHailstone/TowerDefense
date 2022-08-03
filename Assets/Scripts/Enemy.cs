using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public float movementSpeed = 10f;

	private Transform target;
	private int wavepointIndex = 0;

	private void Start()
	{
		target = Waypoints.points[0];

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
				Debug.Log("Take Damage!");
				Destroy(gameObject);
				return;
			}
			wavepointIndex++;
			target = Waypoints.points[wavepointIndex];
		}

	}

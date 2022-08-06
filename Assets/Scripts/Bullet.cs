using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 25f;
    public GameObject impactEffect;

	public float explosionRadius = 0f;
	//transferred the target information from the turret tracking script
	public void Seek(Transform _target)
	{
		target = _target;
	}

	public Transform target;



	// Update is called once per frame
	void Update()
	{
		
		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);


	}


	void HitTarget()
	{
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 5f);



		if (explosionRadius > 0f)
		{
			Explode();

		} else
		{
			Damage(target);
		}
		Destroy(gameObject);

	}


	void Explode()
		{
			//allows us to get an array of targets within the spere with radius explosionRadius.
			Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
			foreach (Collider collider in colliders)
			{
				if (collider.tag == "Enemy")
				{
					Damage(collider.transform);
				}	
			}
	}
	void Damage(Transform enemy)
	{
		Destroy(enemy.gameObject);
	}
}

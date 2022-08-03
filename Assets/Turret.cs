using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [Header("General")]
    //only using pulic to make sure that the targetting system is working (grabbing the closest)
    public Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
	[Range(1f, 100f)]
	public float rotationSpeed = 10f;

	// Start is called before the first frame update
	void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    //going through all the items TAGGED as enemy, and find the closest one. 
    //Going to check if the closest one is within range, (if any) then set this to our target
    void UpdateTarget()
	{
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies)
		{
            float distanceToEnemey = Vector3.Distance(transform.position, enemy.transform.position);
		    if (distanceToEnemey < shortestDistance)
			{
                shortestDistance = distanceToEnemey;
                nearestEnemy = enemy;
			}
        
        }

		if (nearestEnemy != null && shortestDistance <= range)
		{
            target = nearestEnemy.transform;
            //targetEnemy = nearestEnemy.GetComponent<Enemy>();
            Debug.Log("Current Turret Locked on " + target);
        } else
		{
            target = null;
		}

	}

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        } else
		{
            //Target lock on method
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotationActual = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotationActual.y, 0f);

        }
   


        
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);	
	}


}

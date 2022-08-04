using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [Header("General")]
    //only using pulic to make sure that the targetting system is working (grabbing the closest)
    public Transform target;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
	
	

    [Header("Turret Settings")]
    public float rotationSpeed = 10f;
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;



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

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime; //counts down every 1 second



        }
   


        
    }

    void Shoot()
	{

        //storing our bullet game object as we instantiate this bullet using the (GameObject) casting to get the proper setup
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        //confirming if the bullet is null or not, then running the Seek() from the bullet.cs script.
        if (bullet != null)
            bullet.Seek(target);
    
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);	
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ground : MonoBehaviour
{
	//If turret isn't overlapping and it is on the ground

	public GameObject turret;

	void IsOnGround()
	{
		if (turret.tag == "Turret")
		{
			CanBuild();
		}
	}


	private void OnMouseDown()
	{
		
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		IsOnGround();
	}

	void GetMousePosition()
	{
		//raycast from camera to mouse location to get a transform?
		if (Input.GetMouseButtonDown(0))
		{
			
		}
	}


	void CanBuild()
	{
		Collider col = GetComponent<Collider>();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 1000))
		{
			//if this runs into only terrain collider, no other turret can build.
			if (hit.collider.gameObject.name == "Ground")
			{
				GameObject _turretToBuild = (GameObject)Instantiate(turret, hit.point, Quaternion.identity);
			}
		}
		Debug.Log(ray);
		
	}


}

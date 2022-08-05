using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//This is going to handle decision making if there's something here or not
//also going to handle some user input... highlight etc
// Checking if the player has pressed on the node, and then building something there if nothing there already.





public class Node : MonoBehaviour
{

	public Color hoverColor;
	private Renderer rend;
	private Color startColor;
	private GameObject turret;

	BuildManager buildManager;

	public Vector3 positionOffset;


	private void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;	
	}

	private void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (buildManager.GetTurretToBuild() == null)
		{
			return;
		}


		if (turret != null)
		{
			Debug.Log("Can't Build here, there's already a turret.");
			return;
		}

		//build a turret
		//build manager -> after pressing on the UI, you're able to press the node to instantiate it there.
		GameObject turretToBuild = buildManager.GetTurretToBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
	}



	private void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;


		if (buildManager.GetTurretToBuild() == null)
		{
			return;
		}

		rend.material.color = hoverColor;
	}


	private void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}

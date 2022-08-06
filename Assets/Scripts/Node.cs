using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//This is going to handle decision making if there's something here or not
//also going to handle some user input... highlight etc
// Checking if the player has pressed on the node, and then building something there if nothing there already.





public class Node : MonoBehaviour
{
	[Header("Node Settings")]
	public Color hoverColor;
	public Color notEnoughMoneyColor;



	private Renderer rend;
	private Color startColor;

	[Header("Optional")]
	public GameObject turret;

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

		if (!buildManager.CanBuild)
		{
			return;
		}


		if (turret != null)
		{
			Debug.Log("Can't Build here, there's already a turret.");
			return;
		}

		buildManager.BuildTurretOn(this);
		Debug.Log("Turret Purchased and Built:");
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffset;
	}



	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;


		if (!buildManager.CanBuild)
		{
			return;
		}


		rend.material.color = !buildManager.HasMoney ? notEnoughMoneyColor : hoverColor;
		
	}


	private void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}

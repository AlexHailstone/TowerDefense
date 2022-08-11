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

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;



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
				
		if (turret != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
		{
			return;
		}

		BuildTurret(buildManager.GetTurretToBuild());
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffset;
	}

	void BuildTurret(TurretBlueprint blueprint)
	{
		if (PlayerStats.Money >= blueprint.cost)
		{

			PlayerStats.Money -= blueprint.cost;
			//build a turret
			//build manager -> after pressing on the UI, you're able to press the node to instantiate it there.
			GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
			turret = _turret;
			turretBlueprint = blueprint;
			Debug.Log("Turret Built!");
			GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
			Destroy(effect, 5f);

		}
		else
		{
			Debug.Log("Not enough currency");
		}

	}


	public void UpgradeTurret()
	{
		if (PlayerStats.Money < turretBlueprint.upgradeCost)
		{
			Debug.Log("Not enough money to upgrade.");
			return;
		} else
		{ 

			PlayerStats.Money -= turretBlueprint.upgradeCost;
			
			//remove the old turret
			Destroy(turret);

			//Build the new one.
			GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
			turret = _turret;

			
			GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
			Destroy(effect, 5f);

			isUpgraded = true;

			Debug.Log("Turret Upgraded!");

		}
	}

	public void SellTurret()
	{
		PlayerStats.Money += turretBlueprint.GetSellAmount();

		GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Destroy(turret);
		turretBlueprint = null;
	}



	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;


		if (!buildManager.CanBuild)
		{
			return;
		}
		if (buildManager.HasMoney)
		{
			rend.material.color = hoverColor;
		}
		else
		{
			rend.material.color = notEnoughMoneyColor;
		}
		
	}


	private void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}

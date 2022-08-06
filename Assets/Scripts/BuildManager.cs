using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	//if I only have 1 instance of this... this works fine.
	public static BuildManager instance;
	private void Awake()
	{
		if (instance != null)
		{
			Debug.Log("There's more than one BuildManager in this scene");
			return;
		}	

		instance = this;
	}

	
	private TurretBlueprint turretToBuild;
	[Header("Turret Master List")]
	public GameObject standardTurretPrefab;
	public GameObject rocketLauncherPrefab;

	//this is called a property, the goal is a single-line function that is setting a variable CanBuild.
	//if turretToBuild is true, then CanBuild is true, but this can only be set from the functioncheck
	public bool CanBuild { get { return turretToBuild != null;} }

	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
	}

	public void BuildTurretOn(Node node)
	{
		if (PlayerStats.Money >= turretToBuild.cost)
		{

			PlayerStats.Money -= turretToBuild.cost;
			//build a turret
			//build manager -> after pressing on the UI, you're able to press the node to instantiate it there.
			GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
			node.turret = turret;
			Debug.Log("Turret Built! Currenty left: " + PlayerStats.Money);
			
		} else
		{
			Debug.Log("Not enough currency");
		}

		
	}

}

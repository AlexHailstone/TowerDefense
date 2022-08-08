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
	private Node selectedNode;
	public NodeUI nodeUI;

	public GameObject buildEffect;
	public GameObject sellEffect;
	[Header("Turret Master List")]
	public GameObject standardTurretPrefab;
	public GameObject rocketLauncherPrefab;
	public GameObject laserTurretPrefab;



	//this is called a property, the goal is a single-line function that is setting a variable CanBuild.
	//if turretToBuild is true, then CanBuild is true, but this can only be set from the functioncheck
	public bool CanBuild { get { return turretToBuild != null; } }
	// Returns the variable HasMoney based on whether we have enough money currently or not
	// compared to the turret we're trying to build
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }



	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
		selectedNode = null;
		DeselectNode();
	}

	public TurretBlueprint GetTurretToBuild()
	{
		return turretToBuild;
	}


	public void SelectNode(Node node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}
		selectedNode = node;
		turretToBuild = null;

		nodeUI.SetTarget(node);
	}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide();
	}




}

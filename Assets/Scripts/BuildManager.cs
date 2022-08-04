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


	private GameObject turretToBuild;
	public GameObject standardTurretPrefab;

	private void Start()
	{
		turretToBuild = standardTurretPrefab;
	}

	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}



}

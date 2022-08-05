using UnityEngine;

public class Shop : MonoBehaviour
{

	BuildManager buildManager;

	private void Start()
	{
		buildManager = BuildManager.instance;
	}




	//public because we're going to reference this in the other BuildManager.cs script
	public void purchaseStandardTurret ()
	{

		Debug.Log("Standard Turret Purchaged");
		buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);

	}


	public void purchaseEMPTurret()
	{

		Debug.Log("EMP Turret Purchaged");
		buildManager.SetTurretToBuild(buildManager.rocketLauncherPrefab);
	}


}

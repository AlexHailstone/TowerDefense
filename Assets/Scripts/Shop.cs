using UnityEngine;

public class Shop : MonoBehaviour
{
	public TurretBlueprint standardTurret;
	public TurretBlueprint rocketLauncher;

	BuildManager buildManager;

	private void Start()
	{
		buildManager = BuildManager.instance;
	}




	//public because we're going to reference this in the other BuildManager.cs script
	public void SelectStandardTurret ()
	{

		Debug.Log("Standard Turret Selected");
		buildManager.SelectTurretToBuild(standardTurret);

	}


	public void SelectRocketLauncher()
	{

		Debug.Log("Rocket Launcher Selected");
		buildManager.SelectTurretToBuild(rocketLauncher);
	}


}

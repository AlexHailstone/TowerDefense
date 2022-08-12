using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ground : MonoBehaviour
{
    BuildManager buildManager;
    //I need this turret to be dynamically selected from the shop GetSelectedTurrent()
    public Vector3 positionOffset;


    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;



    private void Start()
	{
        buildManager = BuildManager.instance;

    }

void Update()
	{
        if (Input.GetMouseButtonDown(0))
		{
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            BuildTurret(buildManager.GetTurretToBuild());
		}
	}

    
    void PlaceOnGround()
    {
       
        

    }


    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money >= blueprint.cost)
        {

            PlayerStats.Money -= blueprint.cost;

            Collider col = GetComponent<Collider>();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                //if this runs into only terrain collider, no other turret can build.
                if (hit.collider.gameObject.name == "Ground")
                {
                    //GameObject _turretToBuild = (GameObject)Instantiate(turret, hit.point, Quaternion.identity);

                    //build a turret
                    GameObject _turret = (GameObject)Instantiate(blueprint.prefab, hit.point, Quaternion.identity);
                    turret = _turret;
                    turretBlueprint = blueprint;

                    //BuildEffect
                    Debug.Log("Turret Built!");
                    GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, hit.point, Quaternion.identity);
                    Destroy(effect, 5f);
                }
            }
        }
        else
        {
            Debug.Log("Not enough currency");
        }

    }

}

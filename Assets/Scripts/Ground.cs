using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ground : MonoBehaviour
{

    //I need this turret to be dynamically selected from the shop GetSelectedTurrent()
    public GameObject turret;


    void Update()
	{
        if (Input.GetMouseButtonDown(0))
		{
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            PlaceOnGround();
		}
	}


    void PlaceOnGround()
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

    }

}

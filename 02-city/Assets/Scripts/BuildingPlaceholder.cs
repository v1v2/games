using System;
using UnityEngine;

public class BuildingPlaceholder : MonoBehaviour
{
    public GameObject smallFarmPrefab;
    public GameObject bigFarmPrefab;

    private GameObject placeholderGameObject = null;

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            Global.buildingBeingPlaced = null;
            transform.position = new Vector3(-30f, 0, 0);
        }

        // Should be event
        if (Global.buildingBeingPlaced != null && placeholderGameObject == null) {
            placeholderGameObject = Instantiate(Global.buildingBeingPlaced == "small-farm" ? smallFarmPrefab : bigFarmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
        // Should be event
        if (Global.buildingBeingPlaced == null && placeholderGameObject != null) {
            Destroy(placeholderGameObject);
        }

        if (Global.buildingBeingPlaced != null)
        {
            Plane plane = new Plane(Vector3.up, 0);
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance))
            {
                Vector3 worldPos = ray.GetPoint(distance);
                float step = 1f;
                placeholderGameObject.transform.position = new Vector3((float)Math.Round(Convert.ToDouble(worldPos.x / step)) * step, 0.1f, (float)Math.Round(Convert.ToDouble(worldPos.z / step)) * step);
            }

        }
    }
}

using System;
using UnityEngine;

public class BuildingPlaceholder : MonoBehaviour
{
    public GameObject smallFarmPrefab;
    public GameObject bigFarmPrefab;

    private (int, int) smallFarmSpace = (2, 1);
    private (int, int) bigFarmSpace = (2, 2);

    private GameObject placeholderGameObject = null;

    private GameObject GetPrefabFromKey(string key) {
        return Global.buildingBeingPlaced == "small-farm" ? smallFarmPrefab : bigFarmPrefab;
    }

    private (int, int) GetSpaceFromKey(string key) {
        return Global.buildingBeingPlaced == "small-farm" ? smallFarmSpace : Global.buildingBeingPlaced == "big-farm" ? bigFarmSpace : (0, 0);
    }

    private bool HasEnoughSpace((int, int) coords, (int, int) buildingSpace) {
        for (int i = 0; i < buildingSpace.Item1; i++) {
            for (int j = 0; j < buildingSpace.Item2; j++) {
                // Out of map bounds
                if (coords.Item1 + i >= Map.grid.GetLength(0) || coords.Item2 + j >= Map.grid.GetLength(1)) {
                    return false;
                }
                if (Map.grid[coords.Item1 + i, coords.Item2 + j]) {
                    return false;
                }
            }
        }
        return true;
    }

    private void OccupySpace((int, int) coords, (int, int) buildingSpace) {
        for (int i = 0; i < buildingSpace.Item1; i++)
        {
            for (int j = 0; j < buildingSpace.Item2; j++)
            {
                Map.grid[coords.Item1 + i, coords.Item2 + j] = true;
            }
        }
    }

    private Vector3? GetMouseWorldPosition() {
        Plane plane = new Plane(Vector3.up, 0);
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }
        return null;
    }

    private (int, int) GetMouseCellCoords() {
        Vector3? worldPosMaybe = GetMouseWorldPosition();
        if (worldPosMaybe != null) {
            Vector3 worldPos = (Vector3)worldPosMaybe;
            float step = 1f;
            (int, int) coords = (
                (int)(Math.Round(Convert.ToDouble(worldPos.x / step)) * step),
                (int)(Math.Round(Convert.ToDouble(worldPos.z / step)) * step));
            return coords;
        }
        return (0, 0);
    }

    private bool CanBuildHere((int, int) mouseCellCoords) {
        if (
            mouseCellCoords.Item1 >= 0 && mouseCellCoords.Item1 < Map.grid.GetLength(0) &&
            mouseCellCoords.Item2 >= 0 && mouseCellCoords.Item2 < Map.grid.GetLength(1)
            ) {
            return HasEnoughSpace(mouseCellCoords, GetSpaceFromKey(Global.buildingBeingPlaced));
        }
        return false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            Global.buildingBeingPlaced = "";
            transform.position = new Vector3(-30f, 0, 0);
        }

        // Should be event
        if (Global.buildingBeingPlaced != null && placeholderGameObject == null) {
            placeholderGameObject = Instantiate(GetPrefabFromKey(Global.buildingBeingPlaced), new Vector3(0, 0, 0), Quaternion.identity);
        }
        // Should be event
        if (Global.buildingBeingPlaced == null && placeholderGameObject != null) {
            Destroy(placeholderGameObject);
        }

        if (Global.buildingBeingPlaced != null)
        {
            (int, int) worldPosMaybe = GetMouseCellCoords();
            if (CanBuildHere(worldPosMaybe))
            {
                Vector3 pos = new Vector3(worldPosMaybe.Item1 + 1f, 0.1f, worldPosMaybe.Item2);
                placeholderGameObject.transform.position = pos;

                if (Input.GetMouseButtonDown(0)) {
                    Instantiate(GetPrefabFromKey(Global.buildingBeingPlaced), pos, Quaternion.identity);
                    Destroy(placeholderGameObject);
                    OccupySpace(worldPosMaybe, GetSpaceFromKey(Global.buildingBeingPlaced));
                    Global.buildingsBuilt.Add(Global.buildingBeingPlaced);
                }
            }
            else {
                placeholderGameObject.transform.position = new Vector3(-30f, 0.1f, worldPosMaybe.Item2);
            }
        }
    }
}

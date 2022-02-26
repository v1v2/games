using System;
using UnityEngine;

public class BuildingPlaceholder : MonoBehaviour
{
    public GameObject smallFarmPrefab;
    public GameObject bigFarmPrefab;
    public GameObject smallHousePrefab;
    public GameObject bigHousePrefab;
    public GameObject smallPowerPlantPrefab;
    public GameObject bigPowerPlantPrefab;
    public GameObject smallBusinessPrefab;
    public GameObject bigBusinessPrefab;

    private GameObject placeholderGameObject = null;

    private GameObject GetPrefabFromKey(string key)
    {
        return Global.buildingBeingPlaced == "small-farm"
            ? smallFarmPrefab
            : Global.buildingBeingPlaced == "big-farm"
            ? bigFarmPrefab
            : Global.buildingBeingPlaced == "small-house"
            ? smallHousePrefab
            : Global.buildingBeingPlaced == "big-house"
            ? bigHousePrefab
            : Global.buildingBeingPlaced == "small-power-plant"
            ? smallPowerPlantPrefab
            : Global.buildingBeingPlaced == "big-power-plant"
            ? bigPowerPlantPrefab
            : Global.buildingBeingPlaced == "small-business"
            ? smallBusinessPrefab
            : Global.buildingBeingPlaced == "big-business"
            ? bigBusinessPrefab
            : null;
    }

    private (int, int) GetSpaceFromKey(string key)
    {
        return Global.buildingBeingPlaced == "small-farm"
            ? Global.smallFarmSpace
            : Global.buildingBeingPlaced == "big-farm"
            ? Global.bigFarmSpace
            : Global.buildingBeingPlaced == "small-house"
            ? Global.smallHouseSpace
            : Global.buildingBeingPlaced == "big-house"
            ? Global.bigHouseSpace
            : Global.buildingBeingPlaced == "small-power-plant"
            ? Global.smallPowerPlantSpace
            : Global.buildingBeingPlaced == "big-power-plant"
            ? Global.bigPowerPlantSpace
            : Global.buildingBeingPlaced == "small-business"
            ? Global.smallBusinessSpace
            : Global.buildingBeingPlaced == "big-business"
            ? Global.bigBusinessSpace
            : (0, 0);
    }

    private bool HasEnoughSpace((int, int) coords, (int, int) buildingSpace)
    {
        for (int i = 0; i < buildingSpace.Item1; i++)
        {
            for (int j = 0; j < buildingSpace.Item2; j++)
            {
                // Out of map bounds
                if (coords.Item1 + i >= Map.grid.GetLength(0) || coords.Item2 + j >= Map.grid.GetLength(1))
                {
                    return false;
                }
                if (Map.grid[coords.Item1 + i, coords.Item2 + j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    private void OccupySpace((int, int) coords, (int, int) buildingSpace)
    {
        for (int i = 0; i < buildingSpace.Item1; i++)
        {
            for (int j = 0; j < buildingSpace.Item2; j++)
            {
                Map.grid[coords.Item1 + i, coords.Item2 + j] = true;
            }
        }
    }

    private Vector3? GetMouseWorldPosition()
    {
        Plane plane = new Plane(Vector3.up, 0);
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }
        return null;
    }

    private (int, int) GetMouseCellCoords()
    {
        Vector3? worldPosMaybe = GetMouseWorldPosition();
        if (worldPosMaybe != null)
        {
            Vector3 worldPos = (Vector3)worldPosMaybe;
            float step = 1f;
            (int, int) coords = (
                (int)(Math.Round(Convert.ToDouble(worldPos.x / step)) * step),
                (int)(Math.Round(Convert.ToDouble(worldPos.z / step)) * step));
            return coords;
        }
        return (0, 0);
    }

    private bool CanBuildHere((int, int) mouseCellCoords)
    {
        if (
            mouseCellCoords.Item1 >= 0 && mouseCellCoords.Item1 < Map.grid.GetLength(0) &&
            mouseCellCoords.Item2 >= 0 && mouseCellCoords.Item2 < Map.grid.GetLength(1)
            )
        {
            return HasEnoughSpace(mouseCellCoords, GetSpaceFromKey(Global.buildingBeingPlaced));
        }
        return false;
    }

    private bool HasResources(Cost cost)
    {
        if (cost == null)
        {
            throw new Exception("Cannot find cost");
        }

        if (Global.food < cost.food)
        {
            return false;
        }

        if (Global.people < cost.people)
        {
            return false;
        }

        if (Global.energy < cost.energy)
        {
            return false;
        }

        if (Global.money < cost.money)
        {
            return false;
        }

        return true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Global.buildingBeingPlaced = null;
            transform.position = new Vector3(-30f, 0, 0);
        }

        // Should be event
        if (Global.buildingBeingPlaced != null && placeholderGameObject == null)
        {
            placeholderGameObject = Instantiate(GetPrefabFromKey(Global.buildingBeingPlaced), new Vector3(0, 0, 0), Quaternion.identity);
        }
        // Should be event
        if (Global.buildingBeingPlaced == null && placeholderGameObject != null)
        {
            Destroy(placeholderGameObject);
        }

        if (Global.buildingBeingPlaced != null)
        {
            (int, int) worldPosMaybe = GetMouseCellCoords();
            if (CanBuildHere(worldPosMaybe))
            {
                Vector3 pos = new Vector3(worldPosMaybe.Item1 + 1f, 0.1f, worldPosMaybe.Item2);
                placeholderGameObject.transform.position = pos;

                Cost cost = Global.buildingBeingPlaced == "small-farm"
                    ? Global.smallFarmCost
                    : Global.buildingBeingPlaced == "big-farm"
                    ? Global.bigFarmCost
                    : Global.buildingBeingPlaced == "small-house"
                    ? Global.smallHouseCost
                    : Global.buildingBeingPlaced == "big-house"
                    ? Global.bigHouseCost
                    : Global.buildingBeingPlaced == "small-power-plant"
                    ? Global.smallPowerPlantCost
                    : Global.buildingBeingPlaced == "big-power-plant"
                    ? Global.bigPowerPlantCost
                    : Global.buildingBeingPlaced == "small-business"
                    ? Global.smallBusinessCost
                    : Global.buildingBeingPlaced == "big-business"
                    ? Global.bigBusinessCost
                    : null;

                if (Input.GetMouseButtonDown(0) && HasResources(cost))
                {
                    Instantiate(GetPrefabFromKey(Global.buildingBeingPlaced), pos, Quaternion.identity);
                    Destroy(placeholderGameObject);
                    OccupySpace(worldPosMaybe, GetSpaceFromKey(Global.buildingBeingPlaced));
                    Global.buildingsBuilt.Add(Global.buildingBeingPlaced);
                    if (cost.food > 0)
                    {
                        Global.food -= cost.food;
                    }
                    if (cost.people > 0)
                    {
                        Global.people -= cost.people;
                    }
                    if (cost.energy > 0)
                    {
                        Global.energy -= cost.energy;
                    }
                    if (cost.money > 0)
                    {
                        Global.money -= cost.money;
                    }
                }
            }
            else
            {
                placeholderGameObject.transform.position = new Vector3(-30f, 0.1f, worldPosMaybe.Item2);
            }
        }
    }
}

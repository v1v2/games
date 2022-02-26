using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static int food = 0;
    public static int people = 0;
    public static int energy = 0;
    public static int money = 0;
    public static int days = 0;

    public static string buildingBeingPlaced = null;
    public static List<string> buildingsBuilt = new List<string>();

    public void SetBuildingBeingPlaced(string key) {
        buildingBeingPlaced = key;
    }

    public static async Task DelayAsync(float secondsDelay)
    {
        float startTime = Time.time;
        while (Time.time < startTime + secondsDelay) await Task.Yield();
    }

    private void Start()
    {
        InvokeRepeating("dayTick", 0, 3.0f);
    }

    private void dayTick() {
        days++;
    }
}

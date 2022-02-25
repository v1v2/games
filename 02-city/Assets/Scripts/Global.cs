using System.Threading.Tasks;
using UnityEngine;

public class Global : MonoBehaviour
{
    public int food = 0;
    public int people = 0;
    public int energy = 0;
    public int money = 0;
    public int days = 0;

    public bool[,] grid = new bool[14, 14]; 

    public static string buildingBeingPlaced = null;

    public void SetBuildingBeingPlaced(string key) {
        buildingBeingPlaced = key;
    }

    public static async Task DelayAsync(float secondsDelay)
    {
        float startTime = Time.time;
        while (Time.time < startTime + secondsDelay) await Task.Yield();
    }
}

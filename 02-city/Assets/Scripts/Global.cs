using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class Global : MonoBehaviour
{
    public static int food = 0;
    public static int people = 1;
    public static int energy = 0;
    public static int money = 0;
    public static int days = 0;

    public static string buildingBeingPlaced = null;
    public static List<string> buildingsBuilt = new List<string>();

    private bool hasWon = false;

    private GameObject winPanelObj;
    private GameObject winLabelObj;

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
        InvokeRepeating("dayTick", 0, 5.0f);
        winPanelObj = GameObject.Find("Win Panel");
        winLabelObj = GameObject.Find("Win Label");
        winPanelObj.SetActive(false);
    }

    private void CalculateResources() {
        //int totalPeople = 1;
        buildingsBuilt.ForEach(delegate (string building)
        {
            if (building == "small-farm")
            {
                food += 2;
            }
            if (building == "big-farm")
            {
                food += 5;
            }
            if (building == "small-house")
            {
                people += 2;
            }
            if (building == "big-house")
            {
                people += 5;
            }
            if (building == "small-power-plant") {
                energy += 2;
            }
            if (building == "big-power-plant")
            {
                energy += 5;
            }
            if (building == "small-business") {
                money += 2;
            }
            if (building == "big-business") {
                money += 5;
            }
        });
        //people = totalPeople;
    }

    private void dayTick() {
        if (!hasWon) {
            CalculateResources();
            days++;
        }
        if (money >= 1000)
        {
            winLabelObj.GetComponent<TextMeshProUGUI>().text = "You won in " + days + " days!";
            winPanelObj.SetActive(true);
            hasWon = true;
        }
    }
}

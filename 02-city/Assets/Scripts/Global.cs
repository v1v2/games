using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class Cost
{
    public int food;
    public int people;
    public int energy;
    public int money;

    public Cost(int food, int people, int energy, int money)
    {
        this.food = food;
        this.people = people;
        this.energy = energy;
        this.money = money;
    }
}

public class Gains {
    public int food;
    public int people;
    public int energy;
    public int money;

    public Gains(int food, int people, int energy, int money)
    {
        this.food = food;
        this.people = people;
        this.energy = energy;
        this.money = money;
    }
}

public class Global : MonoBehaviour
{
    public static int days = 0;

    public static int food = 8;
    public static int people = 5;
    public static int energy = 0;
    public static int money = 0;

    // Debug
    //public static int food = 1000;
    //public static int people = 1000;
    //public static int energy = 1000;
    //public static int money = 100;

    public static (int, int) smallFarmSpace = (2, 1);
    public static (int, int) bigFarmSpace = (2, 2);
    public static (int, int) smallHouseSpace = (1, 1);
    public static (int, int) bigHouseSpace = (2, 2);
    public static (int, int) smallPowerPlantSpace = (2, 2);
    public static (int, int) bigPowerPlantSpace = (3, 2);
    public static (int, int) smallBusinessSpace = (1, 1);
    public static (int, int) bigBusinessSpace = (2, 1);

    public static Cost smallFarmCost = new Cost(0, 5, 0, 0); // 5
    public static Cost bigFarmCost = new Cost(0, 6, 2, 2); // 10
    public static Cost smallHouseCost = new Cost(10, 0, 0, 0); // 10
    public static Cost bigHouseCost = new Cost(10, 0, 5, 5); // 20
    public static Cost smallPowerPlantCost = new Cost(0, 20, 0, 0); // 20
    public static Cost bigPowerPlantCost = new Cost(0, 20, 0, 20); // 40
    public static Cost smallBusinessCost = new Cost(20, 20, 20, 0); // 60
    public static Cost bigBusinessCost = new Cost(40, 40, 40, 0); // 120

    public static Gains smallFarmGains = new Gains(2, 0, 0, 0);
    public static Gains bigFarmGains = new Gains(5, 0, 0, 0);
    public static Gains smallHouseGains = new Gains(0, 2, 0, 0);
    public static Gains bigHouseGains = new Gains(0, 5, 0, 0);
    public static Gains smallPowerPlantGains = new Gains(0, 0, 2, 0);
    public static Gains bigPowerPlantGains = new Gains(0, 0, 5, 0);
    public static Gains smallBusinessGains = new Gains(0, 0, 0, 2);
    public static Gains bigBusinessGains = new Gains(0, 0, 0, 5);

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

    private async void Start()
    {
        InvokeRepeating("dayTick", 0, 5.0f);
        winPanelObj = GameObject.Find("Win Panel");
        winLabelObj = GameObject.Find("Win Label");
        winPanelObj.SetActive(false);
        await DelayAsync(3);
        GameObject.Find("Goal Label").SetActive(false);
    }

    private void CalculateResources() {
        buildingsBuilt.ForEach(delegate (string building)
        {
            Gains gains = building == "small-farm"
            ? smallFarmGains
            : building == "big-farm"
            ? bigFarmGains
            : building == "small-house"
            ? smallHouseGains
            : building == "big-house"
            ? bigHouseGains
            : building == "small-power-plant"
            ? smallPowerPlantGains
            : building == "big-power-plant"
            ? bigPowerPlantGains
            : building == "small-business"
            ? smallBusinessGains
            : building == "big-business"
            ? bigBusinessGains
            : null;

            if (gains.food > 0)
            {
                Global.food += gains.food;
            }
            if (gains.people > 0)
            {
                Global.people += gains.people;
            }
            if (gains.energy > 0)
            {
                Global.energy += gains.energy;
            }
            if (gains.money > 0)
            {
                Global.money += gains.money;
            }
        });
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

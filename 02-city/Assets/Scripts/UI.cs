using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{

    private TextMeshProUGUI foodLabel;
    private TextMeshProUGUI peopleLabel;
    private TextMeshProUGUI energyLabel;
    private TextMeshProUGUI moneyLabel;
    private TextMeshProUGUI daysLabel;

    private string GetDetails(Cost cost, Gains gains) {
        string str = "Cost         ";

        if (cost.food > 0) {
            str += "  Food: " + cost.food;
        }
        if (cost.people > 0) {
            str += "  People: " + cost.people;
        }
        if (cost.energy > 0) {
            str += "  Energy: " + cost.energy;
        }
        if (cost.money > 0) {
            str += "  Money: " + cost.money;
        }

        str += "\nGain/day  ";

        if (gains.food > 0)
        {
            str += "  Food: " + gains.food;
        }
        if (gains.people > 0)
        {
            str += "  People: " + gains.people;
        }
        if (gains.energy > 0)
        {
            str += "  Energy: " + gains.energy;
        }
        if (gains.money > 0)
        {
            str += "  Money: " + gains.money;
        }

        return str;
    }

    // Start is called before the first frame update
    void Start()
    {
        foodLabel = GameObject.Find("Food Label").GetComponent<TextMeshProUGUI>();
        peopleLabel = GameObject.Find("People Label").GetComponent<TextMeshProUGUI>();
        energyLabel = GameObject.Find("Energy Label").GetComponent<TextMeshProUGUI>();
        moneyLabel = GameObject.Find("Money Label").GetComponent<TextMeshProUGUI>();
        daysLabel = GameObject.Find("Days Label").GetComponent<TextMeshProUGUI>();

        GameObject.Find("Small Farm Details").GetComponent<TextMeshProUGUI>().text = GetDetails(Global.smallFarmCost, Global.smallFarmGains);
        GameObject.Find("Big Farm Details").GetComponent<TextMeshProUGUI>().text = GetDetails(Global.bigFarmCost, Global.bigFarmGains);
        GameObject.Find("Small House Details").GetComponent<TextMeshProUGUI>().text = GetDetails(Global.smallHouseCost, Global.smallHouseGains);
        GameObject.Find("Big House Details").GetComponent<TextMeshProUGUI>().text = GetDetails(Global.bigHouseCost, Global.bigHouseGains);
        GameObject.Find("Small Power Plant Details").GetComponent<TextMeshProUGUI>().text = GetDetails(Global.smallPowerPlantCost, Global.smallPowerPlantGains);
        GameObject.Find("Big Power Plant Details").GetComponent<TextMeshProUGUI>().text = GetDetails(Global.bigPowerPlantCost, Global.bigPowerPlantGains);
        GameObject.Find("Small Business Details").GetComponent<TextMeshProUGUI>().text = GetDetails(Global.smallBusinessCost, Global.smallBusinessGains);
        GameObject.Find("Big Business Details").GetComponent<TextMeshProUGUI>().text = GetDetails(Global.bigBusinessCost, Global.bigBusinessGains);

        GameObject.Find("Buildings Menu").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foodLabel.text = "Food: " + Global.food;
        peopleLabel.text = "People: " + Global.people;
        energyLabel.text = "Energy: " + Global.energy;
        moneyLabel.text = "Money: " + Global.money + " / 1000";
        daysLabel.text = "Days: " + Global.days;
    }
}

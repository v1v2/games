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

    // Start is called before the first frame update
    void Start()
    {
        foodLabel = GameObject.Find("Food Label").GetComponent<TextMeshProUGUI>();
        peopleLabel = GameObject.Find("People Label").GetComponent<TextMeshProUGUI>();
        energyLabel = GameObject.Find("Energy Label").GetComponent<TextMeshProUGUI>();
        moneyLabel = GameObject.Find("Money Label").GetComponent<TextMeshProUGUI>();
        daysLabel = GameObject.Find("Days Label").GetComponent<TextMeshProUGUI>();
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

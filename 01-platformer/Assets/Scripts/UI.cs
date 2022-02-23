using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    private TextMeshProUGUI coinTmp;
    private GlobalScope globalScope;

    void Start()
    {
        coinTmp = GameObject.Find("Coins").GetComponent<TextMeshProUGUI>();
        globalScope = GameObject.Find("GlobalScope").GetComponent<GlobalScope>();
    }

    // Update is called once per frame
    void Update()
    {
        coinTmp.SetText("Coins: " + globalScope.coinCount);
    }
}

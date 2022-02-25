using UnityEngine;
using TMPro;

public class CoinLabel : MonoBehaviour
{
    private void Start()
    {
        Store.current.onPickUpCoin += OnPickUpCoin;
    }

    private void OnDestroy()
    {
        Store.current.onPickUpCoin -= OnPickUpCoin;
    }

    private void OnPickUpCoin()
    {
        GetComponent<TextMeshProUGUI>().SetText("Coins: " + Store.current.coinCount.ToString());
    }
}

using UnityEngine;

public class CoinSound : MonoBehaviour
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
        GetComponent<AudioSource>().Play();
    }
}

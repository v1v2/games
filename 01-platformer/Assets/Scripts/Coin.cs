using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Character")
        {
            Store.current.PickUpCoin();
            gameObject.SetActive(false);
        }
    }
}

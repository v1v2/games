using UnityEngine;

public class DeadLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Character")
        {
            Store.current.Died();
        }
    }
}

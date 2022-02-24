using UnityEngine;

public class Goal : MonoBehaviour
{
    private bool isQuitting = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isQuitting && other.name == "Character") {
            isQuitting = true;
            Store.current.Win();
        }
    }
}

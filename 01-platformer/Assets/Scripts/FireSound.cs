using UnityEngine;

public class FireSound : MonoBehaviour
{
    private void Start()
    {
        Store.current.onFire += OnFire;
    }

    private void OnDestroy()
    {
        Store.current.onFire -= OnFire;
    }

    private void OnFire()
    {
        GetComponent<AudioSource>().Play();
    }
}

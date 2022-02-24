using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    private void Start()
    {
        Store.current.onKill += OnKill;
    }

    private void OnDestroy()
    {
        Store.current.onKill -= OnKill;
    }

    private void OnKill()
    {
        GetComponent<AudioSource>().Play();
    }
}

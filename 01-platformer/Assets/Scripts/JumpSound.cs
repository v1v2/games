using UnityEngine;

public class JumpSound : MonoBehaviour
{
    private void Start()
    {
        Store.current.onJump += OnJump;
    }

    private void OnDestroy()
    {
        Store.current.onJump -= OnJump;
    }

    private void OnJump()
    {
        GetComponent<AudioSource>().Play();
    }
}

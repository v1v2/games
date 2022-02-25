using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource aus;

    public AudioClip coin;
    public AudioClip explosion;
    public AudioClip fire;
    public AudioClip jump;

    private void Start()
    {
        aus = GetComponent<AudioSource>();
        Store.current.onPickUpCoin += OnPickUpCoin;
        Store.current.onKill += OnExplosion;
        Store.current.onFire += OnFire;
        Store.current.onJump += OnJump;
    }

    private void OnDestroy()
    {
        Store.current.onPickUpCoin -= OnPickUpCoin;
        Store.current.onKill -= OnExplosion;
        Store.current.onFire -= OnFire;
        Store.current.onJump -= OnJump;

    }

    private void OnPickUpCoin()
    {
        aus.PlayOneShot(coin);
    }

    private void OnExplosion()
    {
        aus.PlayOneShot(explosion);
    }

    private void OnFire()
    {
        aus.PlayOneShot(fire);
    }

    private void OnJump()
    {
        aus.PlayOneShot(jump);
    }
}

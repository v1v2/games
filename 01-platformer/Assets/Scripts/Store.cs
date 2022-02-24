using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{
    public static Store current;

    private void Awake()
    {
        current = this;
    }

    public int coinCount = 0;




    public event Action onPickUpCoin;
    public void PickUpCoin()
    {
        coinCount++;
        onPickUpCoin?.Invoke();
    }

    public event Action onJump;
    public void Jump() {
        onJump?.Invoke();
    }

    public event Action onFire;
    public void Fire() {
        onFire?.Invoke();
    }

    public event Action onKill;
    public void Kill()
    {
        onKill?.Invoke();
    }

    public event Action onDied;
    public void Died() {
        SceneManager.LoadScene("Start Screen");
        onDied?.Invoke();
    }

    public event Action onWin;
    public async void Win() {
        onWin?.Invoke();
        await Task.Delay(2000);
        SceneManager.LoadScene("Start Screen");
    }
}

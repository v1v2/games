using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void OnEnemiesToggleChanged() {
        Global.areEnemiesEnabled = GetComponentInChildren<Toggle>().isOn;
    }

    public void PlayGame() {
        SceneManager.LoadScene("Main Level");
    }

    public void QuitGame() {
        Application.Quit();
    }
}

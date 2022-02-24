using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("Main Level");
    }

    public void QuitGame() {
        Application.Quit();
    }
}

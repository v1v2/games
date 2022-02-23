using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private bool isQuitting = false;

    private async void OnTriggerEnter2D(Collider2D other)
    {
        if (!isQuitting && other.name == "Character") {
            isQuitting = true;
            GameObject.Find("You win").GetComponent<TextMeshProUGUI>().enabled = true;
            await Task.Delay(2000);
            GameObject.Find("You win").GetComponent<TextMeshProUGUI>().enabled = false;
            SceneManager.LoadScene("Start Screen");
        }
    }

}

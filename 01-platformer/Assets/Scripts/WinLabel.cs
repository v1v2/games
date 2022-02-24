using UnityEngine;
using TMPro;

public class WinLabel : MonoBehaviour
{
    private void Start()
    {
        Store.current.onWin += OnWin;
    }

    private void OnDestroy()
    {
        Store.current.onWin -= OnWin;
    }

    private void OnWin()
    {
        GetComponent<TextMeshProUGUI>().enabled = true;
    }
}

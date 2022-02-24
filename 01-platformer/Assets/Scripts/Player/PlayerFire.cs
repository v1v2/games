using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Transform pfFire;
    private PlayerControls playerControls;

    void Start()
    {
        playerControls = gameObject.GetComponent<PlayerControls>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Transform fireTransform = Instantiate(pfFire);

            fireTransform.transform.position = transform.position;
            fireTransform.gameObject.GetComponent<Fire>().direction = playerControls.lastDirection;
        }
    }
}

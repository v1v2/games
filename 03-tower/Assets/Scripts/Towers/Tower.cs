using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public string towerName;
    public int cost;
    public float projectileSpeed;
    public float shootFrequency;
    public float range;
    // public GameObject prefab;

    public string GetLabel()
    {
        return towerName + "\n" + cost + "g";
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
    }
}

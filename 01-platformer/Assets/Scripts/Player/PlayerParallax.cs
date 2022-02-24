using UnityEngine;

public class PlayerParallax : MonoBehaviour
{
    private GameObject mountainsLayer;
    private GameObject treesLayer;
    private float initialMountainXOffset;
    private float initialTreesXOffset;

    void Start()
    {
        mountainsLayer = GameObject.Find("Mountains Layer");
        treesLayer = GameObject.Find("Trees Layer");
        initialMountainXOffset = mountainsLayer.transform.localPosition.x;
        initialTreesXOffset = treesLayer.transform.localPosition.x;
    }

    void Update()
    {
        mountainsLayer.transform.localPosition = new Vector3(initialMountainXOffset - 0.2f * transform.position.x, mountainsLayer.transform.localPosition.y, mountainsLayer.transform.localPosition.z);
        treesLayer.transform.localPosition = new Vector3(initialTreesXOffset - 2f * transform.position.x, 0, treesLayer.transform.localPosition.z);
        treesLayer.transform.position = new Vector3(treesLayer.transform.position.x, -2.5f, treesLayer.transform.position.z);
    }
}

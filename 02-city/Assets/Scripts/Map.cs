using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject pfMapCell;
    public static bool[,] grid = new bool[14, 14];

    void Start()
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                GameObject mapCell = Instantiate(pfMapCell, new Vector3(i, 0, j), Quaternion.identity);
                mapCell.transform.parent = gameObject.transform;
            }
        }
    }

    void Update()
    {
        
    }
}

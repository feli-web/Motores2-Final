using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject gridPrefab;   
    public int gridCountX = 5;      
    public int gridCountZ = 5;      
    public float gridSpacing = 4f;  

    void Start()
    {
        SpawnGrids();
    }

    void SpawnGrids()
    {
        for (int x = 0; x < gridCountX; x++)
        {
            for (int z = 0; z < gridCountZ; z++)
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacing, 0f, z * gridSpacing);
                GameObject grid = Instantiate(gridPrefab, spawnPosition, gridPrefab.transform.rotation);
                grid.transform.parent = this.transform;
            }
        }
    }
}

using UnityEngine;

public class UnitsBuilding : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject prefab;

    void Start()
    {
        //spawnPoint = prefab.GetComponent<BuildingStats>().spawnPoint;
    }

    void spawnUnit()
    {
        Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}

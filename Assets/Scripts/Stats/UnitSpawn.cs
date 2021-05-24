using UnityEngine;
using UnityEngine.UI;

public class UnitSpawn : MonoBehaviour
{
    Button spawnButton;
    public GameObject unitPrefab;
    public GameObject spawnPoint;

    void Start()
    {
        spawnButton = GetComponent<Button>();
        spawnButton.onClick.AddListener(spawnUnit);
    }

    void spawnUnit()
    {
        Instantiate(unitPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
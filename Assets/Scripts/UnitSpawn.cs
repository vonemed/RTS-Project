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

    void Update()
    {
        
    }
    void spawnUnit()
    {
        Debug.Log("Spawning Unit");
        Instantiate(unitPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}

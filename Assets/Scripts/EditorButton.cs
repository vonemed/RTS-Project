using UnityEngine;
using UnityEngine.UI;

public class EditorButton : MonoBehaviour
{
    public GameObject prefab; // An object to spawn
    Button self;
    RaycastHit hit;
    GameObject spawnedObj;
    bool placing;
    void Start()
    {
        self = GetComponent<Button>();
        self.onClick.AddListener(spawnObject);
    }

    void Update()
    {
        if(placing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Only collides with "Ground" layer
            if (Physics.Raycast(ray, out hit, 500000f, 1 << 8))
            {
                spawnedObj.transform.position = hit.point;
            }
            //Destroy the blueprint once left mouse button is pressed
            if (Input.GetMouseButton(0))
            {
                spawnedObj.GetComponentInChildren<BuildingStats>().justPlaced = true;
                GameObject.FindObjectOfType<EditorManager>().objectsOnScene.Add(spawnedObj); // Adding placed object into the list of objects on the scene
                placing = false;
            }

            if (Input.GetMouseButton(1))
            {
                Destroy(gameObject);
                placing = false;
            }
        }
    }

    void spawnObject()
    {
        placing = true;
        spawnedObj = Instantiate(prefab);
    }
}

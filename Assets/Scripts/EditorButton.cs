using UnityEngine;
using UnityEngine.UI;

public class EditorButton : MonoBehaviour
{
    public GameObject prefab; // An object to spawn
    Button self;
    RaycastHit hit;
    GameObject spawnedObj;
    bool placing;

    private float rotationSpeed = 200f;
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

            if (Input.GetKey(KeyCode.Z))
            {
                spawnedObj.transform.Rotate(transform.up, -rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.X))
            {
                spawnedObj.transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetMouseButton(0))
            {
                GameObject.FindObjectOfType<EditorManager>().objectsOnScene.Add(spawnedObj); // Adding placed object into the list of objects on the scene
                spawnedObj.GetComponent<ObjectHandler>().saveParameters();
                placing = false;
            }

            if (Input.GetMouseButton(1))
            {
                Destroy(gameObject);
                placing = false;
            }
        }
    }

    public void spawnObject()
    {
        placing = true;
        spawnedObj = Instantiate(prefab);
    }
}

using UnityEngine;

public class Blueprint : MonoBehaviour
{
    RaycastHit hit;
    public GameObject prefab;
    public float rayDistance;

    void Start()
    {
        rayDistance = 25.0f;
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        // Only collides with "Ground" layer
        if (Physics.Raycast(ray, out hit, rayDistance, 1 << 8))
        {
            transform.position = hit.point;
            //Need to lift the building up when blueprint is active
        }
        //Destroy the blueprint once left mouse button is pressed
        if (Input.GetMouseButton(0))
        {
            prefab.GetComponentInChildren<BuildingStats>().justPlaced = true;
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (Input.GetMouseButton(1))
        {
            Destroy(gameObject);
        }
    }
}

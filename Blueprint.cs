using UnityEngine;

public class Blueprint : MonoBehaviour
{

    RaycastHit hit;
    Vector3 movePooint;
    public GameObject prefab;

    void Start()
    {
       
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
        if (Physics.Raycast(ray, out hit, 50000.0f,1 << 8))
        {
            transform.position = hit.point;
        }
        //Destroy the blueprint once left mouse button is pressed
        if (Input.GetMouseButton(0))
        {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

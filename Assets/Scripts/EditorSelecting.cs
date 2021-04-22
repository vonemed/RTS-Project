using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorSelecting : MonoBehaviour
{
    RaycastHit hit;
    bool selected;
    public Text[] textArray;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // A very rough way to limit the selection
            if (Input.mousePosition.y < 160)
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

            if (Physics.Raycast(ray, out hit, 50000.0f))
            {
                //Debug.Log(hit.collider.name);

                if (hit.collider.GetComponent<WorldObject>())
                {
                    onSelect(hit.transform.gameObject);
                    selected = true;
                }
                if (hit.collider.tag == "Ground")
                {
                    selected = false;
                }
            }
        }

    }

    void onSelect(GameObject _selectedObject)
    {
        if (selected)
        {
            _selectedObject.AddComponent<Selected>();

            textArray[0].text = _selectedObject.GetComponent<WorldObject>().objectName;

        }
        else
        {
            Destroy(_selectedObject.GetComponent<Selected>());

            //TODO
            //For loop to clear up all the text
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Selecting : MonoBehaviour
{
    Select_dictionary objectsList;

    RaycastHit hit;

    //UI stuff
    public Text _name;
    public Text hp;
    public Image icon;

    public GameObject descButton1;
    public GameObject descButton2;
    
    ResourceStats resourceStats;
    WorldObject current;
    bool selected;

    void Start()
    {
        objectsList = GetComponent<Select_dictionary>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // A very rough way to limit the selection
            if(Input.mousePosition.y < 160)
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

            if (Physics.Raycast(ray, out hit, 50000.0f))
            {
                //Debug.Log(hit.collider.name);

                if (hit.collider.tag == "Building")
                {
                    objectsList.deselectAll();
                    objectsList.addSelected(hit.transform.gameObject);
                    selected = true;
                    onSelect(hit.transform.gameObject);
                }
                if (hit.collider.tag == "Ground")
                {
                    selected = false;
                    objectsList.deselectAll();

                    // Disabling description upon deselecting
                    _name.text = " ";
                    hp.text = " ";
                    icon.enabled = false;
                    descButton1.gameObject.SetActive(false);
                    descButton2.gameObject.SetActive(false);

                }
                if (hit.collider.tag == "Unit")
                {
                    objectsList.deselectAll();
                    objectsList.addSelected(hit.transform.gameObject);
                    selected = true;
                    onSelect(hit.transform.gameObject);
                }

                if (hit.collider.tag == "Resource")
                {
                    /*resourceStats = hit.transform.GetComponent<ResourceStats>();
                    _name.text = resourceStats.nameTag;*/
                }
            }
        }

        if(Input.GetMouseButtonDown(1) && selected == true)
        {
            hit.transform.GetComponent<UnitMovement>();
        }
    }

    void onSelect(GameObject _selectedObject)
    {
        descButton1.gameObject.SetActive(false);
        descButton2.gameObject.SetActive(false);

        current = _selectedObject.GetComponent<WorldObject>();

        //Updating description of selected object
        _name.text = current.objectName; // Name
        hp.text = "HP: " + current.currentHP; // Hp
        icon.enabled = true;
        icon.sprite = current.icon; // Icon

    }
}

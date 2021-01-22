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
    
    BuildingsCreator database;
    BuildingStats target;
    bool selected;

    void Start()
    {
        objectsList = GetComponent<Select_dictionary>();
        database = GetComponent<BuildingsCreator>();
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
                Debug.Log(hit.collider.name);

                if (hit.collider.tag == "Building")
                {
                    objectsList.addSelected(hit.transform.gameObject);

                    onSelectBuilding();

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
                }
            }
        }

        if(Input.GetMouseButtonDown(1) && selected == true)
        {
            hit.transform.GetComponent<UnitMovement>();
        }
    }

    void onSelectBuilding()
    {
        target = hit.transform.GetComponent<BuildingStats>();
        // NEED TO CLEAN UP THE CODE
        //Updating description of selected object
        _name.text = target.nameTag; // Name
        hp.text = "HP: " + target.hp; // Hp
        icon.enabled = true;
        icon.sprite = target.icon; // Icon

        descButton1.gameObject.SetActive(true);
        descButton2.gameObject.SetActive(true);

        // TODO: MOVE THIS CODE TO THE BUILDING STATS
        descButton1.GetComponent<Button>().image.sprite = target.unitIcon1;
        descButton2.GetComponent<Button>().image.sprite = target.unitIcon2;

        // Assigning the description ui buttons to the building buttons
        target.button1 = descButton1;
        target.button2 = descButton2;
    }
}

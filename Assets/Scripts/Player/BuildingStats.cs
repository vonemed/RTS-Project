using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BuildingStats : MonoBehaviour
{
    //UI
    //Parameters
    [Header("Parameters")]
    public int hp;
    public string nameTag;
    public int gold_cost;
    public int wood_cost;
    public int minerals_cost;

    [Header("Visuals")]
    public Sprite icon;
    public Sprite unitIcon1;
    public Sprite unitIcon2;

    public GameObject button1;
    public GameObject button2;

    // Utility
    [Header("Utility")]
    public GameObject spawn;
    public GameObject unit;
    public GameObject unit2;
    public ResourcesUI eventSystem;
    public bool justPlaced;

    public bool townHall;
    public bool barracks;
    public bool special;

    bool selected;

    void Start()
    {
        eventSystem = FindObjectOfType<ResourcesUI>();
    }
    void Update()
    {
        if(GetComponent<Selected>())
        {
            selected = true;
        }
        if(justPlaced)
        {
            deductCost();
            justPlaced = false;
        }

        if (button1 && button2 && selected)
        {
            if (townHall)
            {
                //Need a shortcut
                //Button1
                button1.GetComponent<UnitSpawn>().enabled = true;
                button1.GetComponent<UnitSpawn>().unitPrefab = unit;
                button1.GetComponent<UnitSpawn>().spawnPoint = spawn;
                townHall = false; //Stop flag for now

                //Button2
                button2.GetComponent<BuildingUpgrade>().enabled = true;
                button2.GetComponent<BuildingUpgrade>().hp = hp;
                button2.GetComponent<BuildingUpgrade>().currentBuilding = this;

            }
            if (barracks)
            {
                button1.GetComponent<UnitSpawn>().enabled = true;
                button1.GetComponent<UnitSpawn>().unitPrefab = unit;
                button1.GetComponent<UnitSpawn>().spawnPoint = spawn;
                barracks = false;

                button2.GetComponent<UnitSpawn>().enabled = true;
                button2.GetComponent<UnitSpawn>().unitPrefab = unit;
                button2.GetComponent<UnitSpawn>().spawnPoint = spawn;
            }
            if(special)
            {
                 
            }
        }

        if(!selected && button1 && button2)
        {
            //THIS IS NOT OPTIMAl
            button1.GetComponent<UnitSpawn>().enabled = false;
            button2.GetComponent<UnitSpawn>().enabled = false;
            button2.GetComponent<BuildingUpgrade>().enabled = false;
        }
    }

    void deductCost()
    {
        //Deducting the resources required to build
        eventSystem.gold_num -= gold_cost;
        eventSystem.wood_num -= wood_cost;
        eventSystem.minerals_num -= minerals_cost;
    }
}

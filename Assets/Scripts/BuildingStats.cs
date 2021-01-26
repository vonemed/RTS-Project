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
    public ResourcesUI eventSystem;
    public bool justPlaced;

    public bool townHall;
    public bool barracks;
    public bool special;

    void Start()
    {
        eventSystem = FindObjectOfType<ResourcesUI>();
    }
    void Update()
    {
        if(justPlaced)
        {
            deductCost();
            justPlaced = false;
        }

        if (button1 && button2)
        {
            if (townHall)
            {
                //Need a shortcut
                //Button1
                button1.AddComponent<UnitSpawn>();
                button1.GetComponent<UnitSpawn>().unitPrefab = unit;
                button1.GetComponent<UnitSpawn>().spawnPoint = spawn;
                townHall = false; //Stop flag for now

                //Button2
                button2.AddComponent<BuildingUpgrade>();
                button2.GetComponent<BuildingUpgrade>().hp = hp;
                button2.GetComponent<BuildingUpgrade>().currentBuilding = this;

            }
            if (barracks)
            {

            }
            if(special)
            {
                 
            }
        }
    }

    void deductCost()
    {
        //Deducting the resources required to build
        eventSystem.GetComponent<ResourcesUI>().gold_num -= gold_cost;
        eventSystem.GetComponent<ResourcesUI>().wood_num -= wood_cost;
        eventSystem.GetComponent<ResourcesUI>().minerals_num -= minerals_cost;
    }
}

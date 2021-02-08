using System.Collections;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    //UI
    //Parameters
    [Header("Parameters")]
    public int hp;
    public int armor;
    public string nameTag;
    public int gold_cost;
    public int food_cost;
    public int wood_cost;
    public int minerals_cost;

    [Header("Gatherer")]
    float gatheringRate;
    float gatheringRest;
    int gatheringValue;

    bool gathering;
    bool gold;
    bool wood;
    bool mineral;

    [Header("Visuals")]
    public Sprite icon;

    // Utility
    [Header("Utility")]
    public ResourcesUI eventSystem;
    public ResourceStats resStats;
    public bool gatherer;
    public bool melee;
    public bool archer;
    public bool special;


    RaycastHit hit;

    void Start()
    {
        //Gatherer 
        gatheringValue = 10;
        gatheringRate = 1f;
        gatheringRest = 0;

        eventSystem = FindObjectOfType<ResourcesUI>();

    }
    void Update()
    {
        if (GetComponent<Selected>() && gatherer)
        {
            if (Input.GetMouseButton(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

                if (Physics.Raycast(ray, out hit, 50000.0f))
                {
                    if(hit.collider.name == "GoldMine")
                    {
                        resStats = hit.transform.GetComponent<ResourceStats>();
                        gathering = true;
                        gold = true;
                        //Check the distance to the mine
                        //If the unit is close enough start gathering resource
                    }
                    if (hit.collider.name == "ForestTree")
                    {
                        resStats = hit.transform.GetComponent<ResourceStats>();
                        gathering = true;
                        wood = true;
                    }
                    if (hit.collider.name == "Mineral")
                    {
                        resStats = hit.transform.GetComponent<ResourceStats>();
                        gathering = true;
                        mineral = true;
                    }
                    else
                    {
                        gathering = false;
                    }
                }
            }
        }
        if (gathering)
        {
            if (gatheringRest <= 0)
            {
                if (gold)
                {
                    resStats.goldNum -= gatheringValue;
                    eventSystem.gold_num += gatheringValue;
                }

                if (wood)
                {
                    resStats.woodNum -= gatheringValue;
                    eventSystem.wood_num += gatheringValue;
                }

                if (mineral)
                {
                    resStats.mineralNum -= gatheringValue;
                    eventSystem.minerals_num += gatheringValue;
                }

                gatheringRest = 2f / gatheringRate;
            }
        }

        if (gatheringRest >= 0)
        {
            gatheringRest -= Time.deltaTime;
        }
    }

}

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
                        Debug.Log("WE GOT GOLD!");
                        resStats = hit.transform.GetComponent<ResourceStats>();

                        gathering();
                        //Check the distance to the mine
                        //If the unit is close enough start gathering resource
                        //Access resource UI and start to add resource at specific rate and deducting it from resource stats of selected resource deposit
                    }
                }
            }
        }
    }

    void gathering()
    {
        
    }
}

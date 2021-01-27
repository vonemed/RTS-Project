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
    public bool gatherer;
    public bool melee;
    public bool archer;
    public bool special;

    RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 50000.0f))
            {

            }
        }
    }
}

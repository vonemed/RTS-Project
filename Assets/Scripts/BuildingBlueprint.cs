using System.Collections;
using UnityEngine;

[System.Serializable]
public class BuildingBlueprint 
{
    public GameObject prefab;
    public int gold_cost;
    public string name;

    public BuildingBlueprint(int _cost, string _name)
    {
        gold_cost = _cost;
        name = _name;
    }
}

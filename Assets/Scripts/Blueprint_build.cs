using UnityEngine;

public class Blueprint_build : MonoBehaviour
{
    public GameObject townhall_blueprint;
    public GameObject barracks_blueprint;
    public GameObject house_blueprint;
    public GameObject special_blueprint;

    public void SpawnTownHallBlueprint()
    {
        Instantiate(townhall_blueprint);
    }
    public void SpawnBarracksBlueprint()
    {
        Instantiate(barracks_blueprint);
    }
    public void SpawnSpecialBlueprint()
    {
        Instantiate(special_blueprint);
    }

    public void SpawnHouseBlueprint()
    {
        Instantiate(house_blueprint);
    }
}

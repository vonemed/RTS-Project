using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BuildingStats : MonoBehaviour
{
    //UI
    public int hp;
    public string nameTag;
    public Sprite icon;
    public Sprite unitIcon1;
    public Sprite unitIcon2;
    public GameObject button1;
    public GameObject button2;

    public bool townHall;
    public bool barracks;
    public bool special;

    // Utility
    public GameObject spawn;
    public GameObject unit;

    void Update()
    {
        if(button1 && button2)
        {
            if(townHall)
            {
                button1.AddComponent<UnitSpawn>();
                button2.AddComponent<BuildingUpgrade>();

                button1.GetComponent<UnitSpawn>().unitPrefab = unit;
                button1.GetComponent<UnitSpawn>().spawnPoint = spawn;
                townHall = false; //Stop flag for now
            }
            if(barracks)
            {

            }
            if(special)
            {
                 
            }
        }
    }
}

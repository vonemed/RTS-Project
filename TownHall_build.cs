using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall_build : MonoBehaviour
{
    public GameObject townhall_blueprint;

    public void SpawnBlueprint()
    {
        Instantiate(townhall_blueprint);
    }
}

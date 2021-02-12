using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Unit
{
    public ResourcesUI eventSystem;
    public ResourceStats resStats;

    public Melee()
    {
        hp = 200;
        g_cost = 250;
        f_cost = 150;
    }
    void Start()
    { 
        eventSystem = FindObjectOfType<ResourcesUI>();
        aniMan = GetComponent<AnimationsManager>();
    }

    void Update()
    {
        if(GetComponent<Selected>())
        {
            if(Input.GetMouseButtonDown(1))
            {
                onRightClick();

                if(hit.transform.gameObject.GetComponent<EnemyUnit>())
                {
                    Debug.Log("Attacking");
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Unit
{
    public ResourcesUI eventSystem;
    public ResourceStats resStats;
    UnitMovement motor;


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
        motor = GetComponent<UnitMovement>();
    }

    void Update()
    {
        if(GetComponent<Selected>())
        {
            if(Input.GetMouseButtonDown(1))
            {
                onRightClick();
                motor.MoveTo(hit.point);

                if (hit.transform.gameObject.GetComponent<EnemyUnit>())
                {
                    aniMan.setAnimation(4);
                }
            }
        }
    }
}

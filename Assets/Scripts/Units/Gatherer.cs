﻿using UnityEngine;
using System.Collections;

public class Gatherer : Unit
{
    bool gathering;
    bool gold;
    bool wood;
    bool mineral;

    float gatheringRate;
    float gatheringRest;
    int gatheringValue;
    public ResourcesUI eventSystem;
    public ResourceStats resStats;
    UnitMovement motor;
    Vector3 dist;

    public Gatherer() 
    {
        hp = 100;
        g_cost = 100;
        f_cost = 100;
    }

    void Start()
    {
        //Gatherer 
        gatheringValue = 10;
        gatheringRate = 1f;
        gatheringRest = 0;

        eventSystem = FindObjectOfType<ResourcesUI>();
        aniMan = GetComponent<AnimationsManager>();
        motor = GetComponent<UnitMovement>();
    }

    void Update()
    {
        if (GetComponent<Selected>())
        {
            if (Input.GetMouseButtonDown(1))
            {
                onRightClick();
                motor.MoveTo(hit.point);

                if (hit.collider.name == "GoldMine")
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
                if (hit.collider.name == "Ground")
                {
                    gathering = false;
                }
            }
        }

        if (gathering)
        {
            //Break down if resources are depleted
            if (!resStats)
            {
                aniMan.setAnimation(1);
                gathering = false;
                return;
            }


            dist = motor.distanceCheck(gameObject.transform.position, motor.targetPos);

            if (gatheringRest <= 0 && dist.magnitude <= 1.5f)
            {
                aniMan.setAnimation(3);

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
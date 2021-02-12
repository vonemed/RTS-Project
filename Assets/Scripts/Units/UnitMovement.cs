using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    NavMeshAgent agent;
    AnimationsManager animManager;
    Vector3 dir;
    Vector3 dest;

    [SerializeField]
    bool moving;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animManager = GetComponent<AnimationsManager>();
    }

    void Update()
    {
        //If unit has been selected
        if (transform.GetComponent<Selected>())
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    moving = true;
                    //agent.isStopped = false;
                    dest = hit.point;
                    agent.transform.LookAt(hit.point);
                    agent.SetDestination(hit.point);
                    animManager.setAnimation(2);
                }
            }

        }

        if(moving)
        {
            dir = dest - transform.position;

            if (dir.magnitude <= 0.5f && animManager.currentId != 3)
            {
                animManager.setAnimation(1);
                //agent.isStopped = true;
                moving = false;
            }
        }
    }
}

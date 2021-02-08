using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public RuntimeAnimatorController sprint;
    public RuntimeAnimatorController idle;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
                    Debug.Log(hit.point);
                    agent.SetDestination(hit.point);
                    GetComponent<Animator>().runtimeAnimatorController = sprint;
                }
            }

        }

        if(agent)
        {
            GetComponent<Animator>().runtimeAnimatorController = idle;
        }
    }
}

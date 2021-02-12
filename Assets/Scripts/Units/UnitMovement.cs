using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    NavMeshAgent agent;
    AnimationsManager animManager;
    public Vector3 dist;
    public Vector3 targetPos;

    [SerializeField]
    bool moving;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animManager = GetComponent<AnimationsManager>();
    }

    void Update()
    {
        if(moving)
        {
            dist = distanceCheck(gameObject.transform.position, targetPos);

            if(dist.magnitude <= 0.5f && animManager.currentId == 2)
            {
                animManager.setAnimation(1);
                moving = false;
            }
        }
    }

    public void MoveTo(Vector3 _target)
    {
        targetPos = _target;
        agent.transform.LookAt(_target);
        agent.SetDestination(_target);
        animManager.setAnimation(2);
        moving = true;
    }

    //Check the distance between this object and target
    public Vector3 distanceCheck(Vector3 _origin, Vector3 _target)
    {
        return _origin - _target;
    }
}

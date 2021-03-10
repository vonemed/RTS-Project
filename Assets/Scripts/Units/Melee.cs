using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WorldObject))]
public class Melee : MonoBehaviour
{
    //UI data
    public ResourcesUI eventSystem;
    public ResourceStats resStats;
    UnitMovement motor;
    public HealthBar healthUI;

    //Attacking data
    float attackRate;
    float attackRest;
    int damage;

    //Data for tracking enemies
    bool attacking;
    Vector3 dist;
    RaycastHit hit;

    WorldObject self;
    WorldObject target;

    void Start()
    {
        self = GetComponent<WorldObject>();
        eventSystem = FindObjectOfType<ResourcesUI>();
        self.aniMan = GetComponent<AnimationsManager>();
        motor = GetComponent<UnitMovement>();
        healthUI = GetComponentInChildren<HealthBar>();

        self.setHP(250);
        self.g_cost = 150;
        self.player = true;

        attackRate = 2;
        attackRest = 0;
        damage = 25;
    }

    void Update()
    {
        if(GetComponent<Selected>())
        {
            if(Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit, 50000f);
                motor.MoveTo(hit.point);

                if(hit.transform.gameObject.TryGetComponent<WorldObject>(out target))
                {
                    attacking = true;
                }
                else if (hit.collider.name == "Ground")
                {
                    attacking = false;
                }
            }

            if(attacking)
            {
                dist = motor.distanceCheck(gameObject.transform.position, motor.targetPos);

                if (attackRest <= 0 && dist.magnitude <= 2.5f)
                {
                    self.aniMan.setAnimation(4);
                    target.GetComponent<WorldObject>().ReceiveDamage(damage);
                    attackRest = 2f / attackRate;
                }
            }
        }


        if (attackRest >= 0)
        {
            attackRest -= Time.deltaTime;
        }
    }

    void Attack(int _damage, GameObject _target)
    {
        _target.GetComponent<WorldObject>().ReceiveDamage(_damage); // Problem with unit class
    }
}

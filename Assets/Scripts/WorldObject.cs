using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldObject : MonoBehaviour
{
    public string objectName;
    public int maxHP;
    public int currentHP;
    public Sprite icon;

    public int g_cost;
    public int w_cost;
    public int f_cost;
    public int m_cost;

    public AnimationsManager aniMan;
    public HealthBar healthUI;

    public bool player;
    public bool ai;

    void Awake()
    {
        healthUI = GetComponentInChildren<HealthBar>();
    }

    void Update()
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ReceiveDamage(int _damage)
    {
        currentHP -= _damage;
        healthUI.setHp(currentHP);
    }

    public void setHP(int _hp)
    {
        maxHP = _hp;
        currentHP = maxHP;

        //if(healthUI) // TODO: Remove it once assigned every object a health bar
        //healthUI.setMaxHp(maxHP);
    }
}

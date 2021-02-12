using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float hp;
    public float speed;

    public int g_cost;
    public int w_cost;
    public int f_cost;
    public int m_cost;

    public AnimationsManager aniMan;
    public RaycastHit hit;

    public void onRightClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000f))
        {

        }
    }
}

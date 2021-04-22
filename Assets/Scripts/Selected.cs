using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    void Start()
    {
        //Trying to access Renderer, depending where its located
        if (TryGetComponent(out Renderer rend))
        {
            rend.material.color = Color.red;
        }
        else
        {
            GetComponentInChildren<Renderer>().material.color = Color.red;
        }
    }

    private void OnDestroy()
    {
        if (TryGetComponent(out Renderer rend))
        {
            rend.material.color = Color.white;
        }
        else
        {
            GetComponentInChildren<Renderer>().material.color = Color.white;
        }
    }
}

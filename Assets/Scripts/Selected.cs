using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnDestroy()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}

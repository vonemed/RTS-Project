using System.Collections;
using UnityEngine;

public class ResourceStats : MonoBehaviour
{
    [Header("Parameters")]
    public string nameTag;
    public bool gold;
    public bool wood;
    public bool mineral;

    [Header("Utility")]
    public int goldNum;
    public int woodNum;
    public int mineralNum;

    void Start()
    {
        if(gold)
        {
            goldNum = 1000;
        }

        if(wood)
        {
            woodNum = 300;
        }

        if(mineral)
        {
            mineralNum = 100;
        }
    }

    void Update()
    {
        if(goldNum <= 0 && woodNum <= 0 && mineralNum <= 0)
        {
            Destroy(gameObject);
        }
    }
}

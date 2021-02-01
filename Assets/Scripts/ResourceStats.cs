using System.Collections;
using UnityEngine;

public class ResourceStats : MonoBehaviour
{
    [Header("Parameters")]
    public string nameTag;
    public int amount;
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
}

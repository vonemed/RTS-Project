using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
    [Header("Gold")]
    public Text gold_text;
    public int gold_num;

    [Header("Wood")]
    public Text wood_text;
    public int wood_num;

    [Header("Food")]
    public Text food_text;
    public int food_num;

    [Header("Minerals")]
    public Text minerals_text;
    public int minerals_num;

    void Start()
    {
        gold_num = 500;
        wood_num = 200;
        food_num = 300;
        minerals_num = 50;
    }

    void Update()
    {
        gold_text.text = "Gold: " + gold_num;
        wood_text.text = "Wood: " + wood_num;
        food_text.text = "Food: " + food_num;
        minerals_text.text = "Minerals: " + minerals_num;
    }
}

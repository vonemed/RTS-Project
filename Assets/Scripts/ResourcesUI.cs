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
    [SerializeField] int wood_num;

    [Header("Food")]
    public Text food_text;
    [SerializeField] int food_num;

    [Header("Minerals")]
    public Text minerals_text;
    [SerializeField] int minerals_num;

    void Start()
    {
        gold_num = 150;
        wood_num = 100;
        food_num = 100;
        minerals_num = 100;
    }

    void Update()
    {
        gold_text.text = "Gold: " + gold_num;
        wood_text.text = "Wood: " + wood_num;
        food_text.text = "Food: " + food_num;
        minerals_text.text = "Minerals: " + minerals_num;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class BuildingButtons : MonoBehaviour
{
    // Serializing for Debug purposes
    [SerializeField]
    Button unitButton1;
    [SerializeField]
    Button unitButton2;

    void Start()
    {
        //unitButton1 = FindObjectOfType();
        unitButton2 = GetComponentInChildren<Button>();
    }

    void Update()
    {
        
    }
}

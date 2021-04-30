using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour
{
    Button saveButton;

    void Start()
    {
        saveButton = GetComponent<Button>();
        saveButton.onClick.AddListener(Saving);
    }
    void Saving()
    {
        //Add all of the positions of gameobjects
        Debug.Log("Game was saved!");
    }

}

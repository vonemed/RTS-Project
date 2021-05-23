using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditorUI : MonoBehaviour
{
    public Button exitButton;
    public Button buildTab;
    public Button unitTab;
    public Button miscTab;
    public Button[] buttonsArray = new Button[4]; // Array to hold buttons

    ObjectsManager objectManagerRef;

    void Start()
    {
        exitButton.onClick.AddListener(ExitEditor);
        buildTab.onClick.AddListener(() => TabSwitch(1));
        unitTab.onClick.AddListener(() => TabSwitch(2));

        objectManagerRef = GetComponent<ObjectsManager>();

        for (int i = 0; i < buttonsArray.Length; i++)
        {
            buttonsArray[i].image.sprite = objectManagerRef.buildingsArray[i].gameObject.GetComponent<WorldObject>().icon; 
            buttonsArray[i].gameObject.AddComponent<EditorButton>().prefab = objectManagerRef.buildingsArray[i]; // Adding a script to the button and assigning a prefab at the same time
        }
    }

    void Update()
    {
        // For testing and developing purposes
        if (Input.GetKeyDown(KeyCode.R))
        {
            buttonsArray[0].GetComponent<EditorButton>().spawnObject();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            buttonsArray[1].GetComponent<EditorButton>().spawnObject();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            buttonsArray[2].GetComponent<EditorButton>().spawnObject();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            buttonsArray[3].GetComponent<EditorButton>().spawnObject();
        }
    }

    void ExitEditor()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void TabSwitch(int _index)
    {
        switch(_index)
        {
            case 1:

                for (int i = 0; i < buttonsArray.Length; i++)
                {
                    buttonsArray[i].image.sprite = objectManagerRef.buildingsArray[i].gameObject.GetComponent<WorldObject>().icon;
                    buttonsArray[i].GetComponent<EditorButton>().prefab = objectManagerRef.buildingsArray[i]; // Adding a script to the button and assigning a prefab at the same time
                }
                //Buildings
                break;

            case 2:

                for (int i = 0; i < buttonsArray.Length; i++)
                {
                    buttonsArray[i].image.sprite = objectManagerRef.unitArray[i].gameObject.GetComponent<WorldObject>().icon;
                    buttonsArray[i].GetComponent<EditorButton>().prefab = objectManagerRef.unitArray[i]; // Adding a script to the button and assigning a prefab at the same time
                }

                //Units
                break;

            case 3:

                //Misc
                break;
        }
    }
}

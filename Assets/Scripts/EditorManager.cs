using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class EditorManager : MonoBehaviour
{
    public List<GameObject> objectsOnScene = new List<GameObject>();
    ObjectsManager objRef;
    public Button saveButton;
    public Button loadButton;
    public Button clearButton;

    string json;

    void Awake()
    {
        CheckLoadedObjects();
    }

    void Start()
    {
        saveButton.onClick.AddListener(SaveGame);
        loadButton.onClick.AddListener(LoadGame);
        clearButton.onClick.AddListener(ClearScene);
        objRef = GetComponent<ObjectsManager>();
        //CheckLoadedObjects();
    }

    void SaveGame()
    {
        //CheckLoadedObjects();
        //Add all of the positions of gameobjects

        json = JsonUtility.ToJson(SaveData.current);

        File.WriteAllText(Application.persistentDataPath + "/gamesave.json", json);

        Debug.Log(json);
    }

    void LoadGame()
    {
        ClearScene();

        if (File.Exists(Application.persistentDataPath + "/gamesave.json"))
        {
            json = File.ReadAllText(Application.persistentDataPath + "/gamesave.json");
            SaveData.current = JsonUtility.FromJson<SaveData>(json);

            for(int i = 0; i < SaveData.current.objectsToSave.Count; i++)
            {
                Debug.Log("Loading objects...");

                ObjectData currentObj = SaveData.current.objectsToSave[i];
                GameObject obj = Instantiate(objRef.buildingsArray[(int)currentObj.objectType]); //???
                ObjectHandler objHandler = obj.GetComponent<ObjectHandler>();
                objHandler.objData = currentObj;
                obj.transform.position = currentObj.objectPos;
                obj.transform.rotation = currentObj.objectRot;

                objectsOnScene.Add(obj);
            }

            Debug.Log("Game Loaded");
        }
    }

    public void ClearScene()
    {
        foreach(GameObject sceneObj in objectsOnScene)
        {
            Destroy(sceneObj);
        }

        objectsOnScene.Clear();
    }

    void CheckLoadedObjects()
    {
        var currentObj = FindObjectsOfType<GameObject>();

        foreach (GameObject gmObj in currentObj)
        {
            if (gmObj.GetComponent<WorldObject>())
            {
                objectsOnScene.Add(gmObj);
            }
        }
    }
}

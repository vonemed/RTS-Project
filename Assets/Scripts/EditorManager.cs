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

    string json;
    void Start()
    {
        saveButton.onClick.AddListener(SaveGame);
        loadButton.onClick.AddListener(LoadGame);
        objRef = GetComponent<ObjectsManager>();
    }

    void SaveGame()
    {
        //Add all of the positions of gameobjects
        Save save = new Save();

        // Saving objects on the scene

        foreach (GameObject currentGameObject in objectsOnScene) // Saving position of objects on the scene
        {
            save.existingObjectsPosition.Add(currentGameObject.GetComponent<Transform>().transform.position);
            save.existingObjects.Add(currentGameObject.GetComponent<WorldObject>().objectName);
            //save.existingObjects.Add(currentGameObject.GetComponent<WorldObject>());
        }

        json = JsonUtility.ToJson(save);
        //FileStream file = File.Create(Application.persistentDataPath + "/gamesave.json"); // C:\Users\gleba\AppData\LocalLow\DefaultCompany
        File.WriteAllText(Application.persistentDataPath + "/gamesave.json", json);

        Debug.Log("Saving as JSON" + save);

        Debug.Log(json);
       //file.Close();
        ClearScene();
        /* /// Binary formatter variant (not working (can't save GameObjects))
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, save);
        */

        /*/// XML variant 
        //Serializing to Xml
        DataContractSerializer bf = new DataContractSerializer(save.GetType());
        MemoryStream streamer = new MemoryStream();

        //Serializing to file   
        bf.WriteObject(streamer, save);
        streamer.Seek(0, SeekOrigin.Begin);

        //Save to disk 
        file.Write(streamer.GetBuffer(), 0, streamer.GetBuffer().Length);

        string result = XElement.Parse(Encoding.ASCII.GetString(streamer.GetBuffer()).Replace("\0", "")).ToString();
        Debug.Log("Serialized Result: " + result);
        */
    }

    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.json"))
        {
            //FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);

            json = File.ReadAllText(Application.persistentDataPath + "/gamesave.json");
            Save LoadSave = JsonUtility.FromJson<Save>(json);

            //file.Close();
            //Problem: If save two of the same prefab, it only loads once
            //and if saved objects are not in the same order as in prefabArray
            foreach (string wrldObj in LoadSave.existingObjects)
            {
                //Solution
                for(int i = 0; i < objRef.prefabArray.Length; i++)
                {
                    if(wrldObj == objRef.prefabArray[i].GetComponent<WorldObject>().objectName)
                    {
                        Instantiate(objRef.prefabArray[i], LoadSave.existingObjectsPosition[i], Quaternion.identity);
                        Debug.Log("Instantiating");
                        break;
                    }
                }

                /*if(wrldObj == objRef.prefabArray[i].GetComponent<WorldObject>().objectName)
                {
                    //Instantiate
                   
                    Instantiate(objRef.prefabArray[i]);
                    i++;

                    //Problem: If save two of the same prefab, it only loads once
                    //and if saved objects are not in the same order as in prefabArray
                    //Solved: with for loop and if function

                    //For loop with if loop
                    //Store transforms not vector3
                }*/
            }

            //TODO 
            //FIND A WAY TO PROPERLY LOAD OBJJECTS

            //Load prefabs from Resources and apply parameters
            //SOLVED

            //TUWTUTUTUTUTU
            //Save the names of the objects
            // Load the save and then compare saved names to the assets object and load proper prefab
            //SOLVED

            //Problem: Can't save previously loaded objects
            Debug.Log("Game Loaded");
        }
    }

    void ClearScene()
    {
        foreach(GameObject sceneObj in objectsOnScene)
        {
            Destroy(sceneObj);
        }

        objectsOnScene.Clear();
    }
}

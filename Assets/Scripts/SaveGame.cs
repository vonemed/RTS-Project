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


public class SaveGame : MonoBehaviour
{
    Button saveButton;
    EditorManager managerRef; // Reference to an editor manager
    public GameObject testPrefab;
    void Start()
    {
        managerRef = GameObject.FindObjectOfType<EditorManager>();
        saveButton = GetComponent<Button>();
        saveButton.onClick.AddListener(Saving);

        testPrefab = Resources.Load("townHall") as GameObject;
    }
    void Saving()
    {
        //Add all of the positions of gameobjects
        Debug.Log("Game was saved!");
        Save save = new Save();

        save.existingObjects = managerRef.objectsOnScene; // Saving objects on the scene

        foreach(GameObject currentGameObject in managerRef.objectsOnScene) // Saving position of objects on the scene
        {
            save.existingObjectsPosition.Add(currentGameObject.transform.position);
        }

        FileStream file = File.Create(Application.persistentDataPath + "/newgamesave.save"); // C:\Users\gleba\AppData\LocalLow\DefaultCompany

        file.Close();

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

        /* /// Json variant
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON" + save);
        */
    }

}

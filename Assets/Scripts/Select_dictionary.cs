using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_dictionary : MonoBehaviour
{
    public Dictionary<int, GameObject> selectedObjects = new Dictionary<int, GameObject>();

    public void addSelected(GameObject _object)
    {
        int id = _object.GetInstanceID();

        // Takes an Id and checks if the dictionary already have one
        if(!(selectedObjects.ContainsKey(id)))
        {
            selectedObjects.Add(id, _object);
            _object.AddComponent<Selected>();
            //Debug.Log("Added " + id + " to selected list");
        }

    }

    public void deselect(int _id)
    {
        Destroy(selectedObjects[_id].GetComponent<Selected>());
        selectedObjects.Remove(_id);
    }

    public void deselectAll()
    {
        foreach(KeyValuePair<int, GameObject> pair in selectedObjects)
        {
            if(pair.Value != null)
            {
                Destroy(selectedObjects[pair.Key].GetComponent<Selected>());
            }
        }

        selectedObjects.Clear();
    }
}

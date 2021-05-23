using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    public ObjectType objType;

    public ObjectData objData;

    public void saveParameters()
    {
        if (string.IsNullOrEmpty(objData.id))
        {
            // Current date + random number
            objData.id = System.DateTime.Now.ToLongDateString() + Random.Range(0, int.MaxValue).ToString();
            objData.objectType = objType;
            SaveData.current.objectsToSave.Add(objData);
        }

        objData.objectPos = gameObject.transform.position;
        objData.objectRot = gameObject.transform.rotation;
    }
}

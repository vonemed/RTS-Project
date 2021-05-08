using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.Runtime.Serialization;

[System.Serializable]
public class Save 
{
    public List<string> existingObjects = new List<string>();
    //public List<WorldObject> existingObjects = new List<WorldObject>();

    public List<Vector3> existingObjectsPosition = new List<Vector3>();
}

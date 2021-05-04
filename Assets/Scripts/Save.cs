using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.Runtime.Serialization;

[DataContract]
public class Save 
{
    [DataMember]
    public List<GameObject> existingObjects = new List<GameObject>();
    [DataMember]
    public List<Vector3> existingObjectsPosition = new List<Vector3>();
}

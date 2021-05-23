using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ObjectType
{
    Townhall,
    Barracks,
    House,
    SpecialBuilding
}

[System.Serializable]
public class ObjectData
{
    public string id;

    public ObjectType objectType;

    public Vector3 objectPos;

    public Quaternion objectRot;
}

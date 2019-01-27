﻿using UnityEngine;

[CreateAssetMenu(fileName = "ObjectVariable", menuName = "Variables/ObjectVariable", order = 3)]
public class ObjectVariable : ScriptableObject
{
    public GameObject value;

    public void SetObject(GameObject gameObject)
    {
        value = gameObject;
    }

    public void ReSetObject()
    {
        value = null;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SpawnObject
{
    public GameObject[] Prefabs;

    public Transform[] Spawners;

    public Type ObjectType;

    public enum Type
    {
        Object,
        Building
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuyableData
{
    public GameObject PrefabReference;
    public Vector3 SpawnPosition, SpawnRotation;
    public float WoodRequirements, StoneRequirements, GoldRequirements;
}

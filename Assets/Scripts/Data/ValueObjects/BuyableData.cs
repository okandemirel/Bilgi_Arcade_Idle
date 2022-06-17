using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuyableData
{
    public GameObject SpawnReference;
    public Vector3 SpawnPosition, SpawnRotation;
    public int WoodRequirement, StoneRequirement, GoldRequirement;
    public bool IsBought;
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyableManager : MonoBehaviour
{
    #region Self Variables

    #region Public Variables

    public BuyableData BuyableData;

    #endregion

    #region Serialized Variables


    [SerializeField] private Collider collider;

    #endregion

    #endregion

    private void Awake()
    {
        collider = GetComponent<Collider>();

        BuyableData = GetData();

    }

    private void Start()
    {
        if (BuyableData.IsBought)
        {
            SpawnTheObject();
        }
    }

    private BuyableData GetData()
    {
        var data = Resources.Load<CD_Buyable>("Data/CD_Buyable_PirateShip").Data;
        return new BuyableData()
        {
            GoldRequirement = data.GoldRequirement,
            SpawnPosition = data.SpawnPosition,
            SpawnReference = data.SpawnReference,
            SpawnRotation = data.SpawnRotation,
            StoneRequirement = data.StoneRequirement,
            WoodRequirement = data.WoodRequirement,
            IsBought = data.IsBought
        };
    }

    private void SpawnTheObject()
    {
        collider.enabled = false;
        Instantiate(BuyableData.SpawnReference, BuyableData.SpawnPosition, Quaternion.Euler(BuyableData.SpawnRotation), transform);
    }

    public void BuyTheObject()
    {
        Instantiate(BuyableData.SpawnReference, BuyableData.SpawnPosition, Quaternion.Euler(BuyableData.SpawnRotation), transform);
        Resources.Load<CD_Buyable>("Data/CD_Buyable_PirateShip").Data.IsBought = true;
    }
}

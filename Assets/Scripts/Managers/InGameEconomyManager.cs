using Assets.Scripts.Enums;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class InGameEconomyManager : MonoBehaviour
{

    #region Singleton 

    public static InGameEconomyManager Instance;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    #endregion

    #region Self Variables

    #region Public Variables

    public CollectableTypes Types;

    #endregion

    #region Serialized Variables

    #endregion

    #region Private Variables

    [ShowInInspector] public static int _wood, _gold, _stone;

    #endregion

    #endregion

    private void Start()
    {
        SubscribeEvents();

        //yield return new WaitForSeconds(.2f);
        //GetEconomyData();
        DOVirtual.DelayedCall(.2f, GetEconomyData);

    }

    private void SubscribeEvents()
    {
        EventManager.Instance.onUpdateCollectableType += OnUpdateCollectableType;
    }

    private void UnsubscribeEvents()
    {
        EventManager.Instance.onUpdateCollectableType -= OnUpdateCollectableType;
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void GetEconomyData()
    {
        if (ES3.FileExists())
        {
            if (ES3.KeyExists("Wood"))
            {
                _wood = ES3.Load<int>("Wood");
                EventManager.Instance.onUpdateUICollectableType?.Invoke(CollectableTypes.Wood, _wood);
            }
            if (ES3.KeyExists("Stone"))
            {
                _stone = ES3.Load<int>("Stone");
                EventManager.Instance.onUpdateUICollectableType?.Invoke(CollectableTypes.Stone, _stone);
            }
            if (ES3.KeyExists("Gold"))
            {
                _gold = ES3.Load<int>("Gold");
                EventManager.Instance.onUpdateUICollectableType?.Invoke(CollectableTypes.Gold, _gold);
            }
        }
    }

    private void OnUpdateCollectableType(CollectableTypes type, int value)
    {

        switch (type)
        {
            case CollectableTypes.Wood:
                {
                    _wood += value;
                    ES3.Save("Wood", _wood);
                    EventManager.Instance.onUpdateUICollectableType?.Invoke(type, _wood);
                    break;
                }
            case CollectableTypes.Stone:
                {
                    _stone += value;
                    ES3.Save("Stone", _stone);
                    EventManager.Instance.onUpdateUICollectableType?.Invoke(type, _stone);
                    break;
                }
            case CollectableTypes.Gold:
                {
                    _gold += value;
                    ES3.Save("Gold", _gold);
                    EventManager.Instance.onUpdateUICollectableType?.Invoke(type, _gold);
                    break;
                }
        }
    }

    public void GetResources(out int wood, out int stone, out int gold)
    {
        wood = _wood;
        stone = _stone;
        gold = _gold;

    }
}

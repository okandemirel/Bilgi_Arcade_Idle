using Assets.Scripts.Enums;
using Assets.Scripts.Managers;
using DG.Tweening;
//using RayFire;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private PlayerManager manager;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Collider collider;

    #endregion


    #region Private Variables

    [ShowInInspector] private bool _isInCuttingState;

    #endregion

    #endregion


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Cuttable"))
        {
            manager.ChangeTheAnimationState(AnimationStates.Cut);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cuttable"))
        {
            if (!_isInCuttingState)
            {
                _isInCuttingState = true;
                DOVirtual.DelayedCall(3, () =>
                {
                    manager.UpdateInGameCurrency(other.GetComponent<CollectableManager>().Type, 3);
                    //manager.CutCuttable(other.transform.GetChild(0).transform.GetComponent<RayfireRigid>());
                }).OnComplete(() => _isInCuttingState = false);
            }
        }

        if (other.CompareTag("Buyable"))
        {
            var data = other.GetComponent<BuyableManager>().BuyableData.Data;
            //EconomyParams inGameEconomyParams = (EconomyParams)(EventManager.Instance.onGetInGameEconomyParams?.Invoke());
            FindObjectOfType<InGameEconomyManager>().GetResources(out int wood, out int stone, out int gold);
            if (wood < data.WoodRequirements) return;
            if (stone < data.StoneRequirements) return;
            if (gold < data.GoldRequirements) return;
            GameObject obj = Instantiate(data.PrefabReference, data.SpawnPosition, Quaternion.Euler(data.SpawnRotation), other.transform);
            EventManager.Instance.onUpdateUICollectableType?.Invoke(CollectableTypes.Wood, (int)(wood - data.WoodRequirements));
            EventManager.Instance.onUpdateUICollectableType?.Invoke(CollectableTypes.Stone, (int)(stone - data.StoneRequirements));
            EventManager.Instance.onUpdateUICollectableType?.Invoke(CollectableTypes.Gold, (int)(gold - data.GoldRequirements));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cuttable"))
        {
            manager.DisableAnimatorCuttingState();
            manager.ChangeTheAnimationState(AnimationStates.Idle);
        }
    }
}
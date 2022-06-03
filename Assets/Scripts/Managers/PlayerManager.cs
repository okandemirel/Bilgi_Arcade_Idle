using Assets.Scripts.Enums;
using DG.Tweening;
//using RayFire;
using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Self Variables

    #region Serialized Variables

    [SerializeField] private PlayerMovementController movementController;
    [SerializeField] private PlayerPhysicsController physicsController;
    [SerializeField] private PlayerAnimationController animationController;

    #endregion

    #region Private Variables


    #endregion

    #endregion

    private void OnEnable()
    {
        AssignEvents();
    }

    private void AssignEvents()
    {
        EventManager.Instance.onInputTaken += OnInputTaken;
        EventManager.Instance.onInputDragged += OnInputDragged;
        EventManager.Instance.onInputReleased += OnInputReleased;
    }



    private void UnAssignEvents()
    {
        EventManager.Instance.onInputTaken -= OnInputTaken;
        EventManager.Instance.onInputDragged -= OnInputDragged;
        EventManager.Instance.onInputReleased -= OnInputReleased;
    }

    private void OnDisable()
    {
        UnAssignEvents();
    }


    private void OnInputTaken()
    {
        animationController.ChangeAnimationState(AnimationStates.Walk);
    }

    private void OnInputDragged(JoystickMovementParams inputParams)
    {
        movementController.SetMovementAvailable();
        movementController.UpdateInputData(inputParams);
    }

    private void OnInputReleased()
    {
        movementController.SetMovementUnavailable();
        animationController.ChangeAnimationState(AnimationStates.Idle);
    }



    public void ChangeTheAnimationState(AnimationStates states)
    {
        animationController.ChangeAnimationState(states);
    }

    //public void CutCuttable(RayfireRigid rigid)
    //{
    //    rigid.ApplyDamage(15, new Vector3(rigid.transform.position.x, 0, rigid.transform.position.z), 5);
    //}

    public void UpdateInGameCurrency(CollectableTypes type, int value)
    {
        EventManager.Instance.onUpdateCollectableType?.Invoke(type, value);
    }

    public void DisableAnimatorCuttingState()
    {
        animationController.DisableAnimatorCuttingState();
    }
}
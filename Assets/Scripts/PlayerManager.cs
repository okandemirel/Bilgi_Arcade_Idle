using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Self Variables

    #region Serialized Variables

    [SerializeField] private PlayerMovementController movementController;
    [SerializeField] private PlayerPhysicsController physicsController;

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
        EventManager.Instance.onInputDragged += OnInputDragged;
        EventManager.Instance.onInputReleased += OnInputReleased;
    }

    private void UnAssignEvents()
    {
        EventManager.Instance.onInputDragged -= OnInputDragged;
        EventManager.Instance.onInputReleased -= OnInputReleased;
    }

    private void OnDisable()
    {
        UnAssignEvents();
    }

    private void OnInputDragged(Vector2 inputParams)
    {
        movementController.SetMovementAvailable();
        movementController.UpdateInputData(inputParams);
    }

    private void OnInputReleased()
    {
        movementController.SetMovementUnavailable();
    }

}
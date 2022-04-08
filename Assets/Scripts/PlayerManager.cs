using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Self Variables

    #region Serialized Variables

    [SerializeField] private PlayerMovementController movementController;

    #endregion

    #region Private Variables
    private Vector2 inputValue;


    #endregion

    #endregion
    private void Update()
    {
        if (Input.anyKey)
        {
            inputValue = InputData;
            movementController.SetMovementAvailable();
            movementController.UpdateInputData(inputValue);
        }
        else
        {
            movementController.SetMovementUnAvailable();
        }
    }

    private Vector2 InputData => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

}
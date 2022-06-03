using Assets.Scripts;
using Assets.Scripts.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{


    #region Self Variables

    #region Public Variables

    public MovementTypes Types;

    #endregion

    #region Serialized Variables


    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed = 6;
    #endregion

    #region Private Variables

    private Vector2 _inputValues;
    #endregion

    #region Private Variables

    private bool _isReadyToMove;
    #endregion

    #endregion


    private void FixedUpdate()
    {
        if (_isReadyToMove && GameManager.Instance.State == Assets.Scripts.Enums.GameStates.Movement)
        {
            MovePlayer();
            RotatePlayer();
        }
        else StopPlayer();
    }

    public void SetMovementAvailable()
    {
        _isReadyToMove = true;
    }

    public void SetMovementUnavailable()
    {
        _isReadyToMove = false;
    }

    public void UpdateInputData(JoystickMovementParams inputValue)
    {
        _inputValues = new Vector2(inputValue.HorizontalInputValue, inputValue.VerticalInputValue);
    }

    private void MovePlayer()
    {
        rigidbody.velocity = new Vector3(_inputValues.x * speed, rigidbody.velocity.y, _inputValues.y * speed);
    }

    private void StopPlayer()
    {
        rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        rigidbody.angularVelocity = Vector3.zero;
    }

    private void RotatePlayer()
    {
        var moveDirection = new Vector3(_inputValues.x,
            0,
            _inputValues.y);
        rigidbody.MoveRotation(Quaternion.LookRotation(moveDirection, Vector3.up));
    }
}

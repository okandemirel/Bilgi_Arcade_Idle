using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{


    #region Self Variables

    #region Serialized Variables


    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed = 6;
    #endregion

    #region Private Variables

    private Vector2 inputValues;
    #endregion

    #region Private Variables

    private bool _isReadyToMove;
    #endregion

    #endregion


    private void FixedUpdate()
    {
        if (_isReadyToMove) MovePlayer();
        else StopPlayer();
    }

    public void SetMovementAvailable()
    {
        _isReadyToMove = true;
    }

    public void SetMovementUnAvailable()
    {
        _isReadyToMove = false;
    }

    public void UpdateInputData(Vector2 inputValue)
    {
        inputValues = inputValue;
    }

    private void MovePlayer()
    {
        rigidbody.velocity = new Vector3(inputValues.x * speed, rigidbody.velocity.y, inputValues.y * speed);
    }

    private void StopPlayer()
    {
        rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        rigidbody.angularVelocity = Vector3.zero;
    }
}

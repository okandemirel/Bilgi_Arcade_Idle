using Assets.Scripts;
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

    private float _inputValues;
    #endregion

    #region Private Variables

    private bool _isReadyToMove;
    #endregion

    #endregion


    private void FixedUpdate()
    {
        if (_isReadyToMove)
        {


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

    public void UpdateInputData(HorizontalnputParams inputValue)
    {
        _inputValues = inputValue.HorizontalInputValue;
    }



    private void StopPlayer()
    {
        rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        rigidbody.angularVelocity = Vector3.zero;
    }
}

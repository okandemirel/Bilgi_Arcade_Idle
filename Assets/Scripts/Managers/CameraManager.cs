using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Transform playerManager;
    #endregion

    #endregion

    #region Event Subscriptions
    private void Start()
    {
        SubscribeEvents();
        playerManager = FindObjectOfType<PlayerManager>().transform;

    }

    private void SubscribeEvents()
    {
        EventManager.Instance.onPlay += OnAssignCameraTarget;
    }

    private void UnsubscribeEvents()
    {
        EventManager.Instance.onPlay -= OnAssignCameraTarget;

    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    #endregion

    private void OnAssignCameraTarget()
    {
        virtualCamera.Follow = playerManager;
        virtualCamera.LookAt = playerManager;
    }

}

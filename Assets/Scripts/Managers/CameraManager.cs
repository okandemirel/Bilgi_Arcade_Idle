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
    }

    private void SubscribeEvents()
    {
        EventManager.Instance.onPlay += OnSetCameraTarget;
    }

    private void UnsubscribeEvents()
    {
        EventManager.Instance.onPlay -= OnSetCameraTarget;

    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    #endregion

    private void OnSetCameraTarget()
    {
        playerManager = FindObjectOfType<PlayerManager>().transform;
        virtualCamera.Follow = playerManager;
        virtualCamera.LookAt = playerManager;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Self Variables


    #region Serialized Variables


    [SerializeField] private GameObject startPanel, winPanel, failPanel, joystickPanel;

    #endregion

    #endregion

    #region Event Subscription
    private void Start()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventManager.Instance.onPlay += OnOpenJoystickPanel;
        EventManager.Instance.onPlay += OnCloseStartPanel;
    }

    private void UnsubscribeEvents()
    {
        EventManager.Instance.onPlay -= OnOpenJoystickPanel;
        EventManager.Instance.onPlay -= OnCloseStartPanel;
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }
    #endregion

    private void OnOpenJoystickPanel()
    {
        joystickPanel.SetActive(true);
    }

    private void OnCloseStartPanel()
    {
        startPanel.SetActive(false);
    }

    public void Play()
    {
        EventManager.Instance.onPlay?.Invoke();
    }


}

using Assets.Scripts.Enums;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Self Variables


    #region Serialized Variables


    [SerializeField] private GameObject startPanel, winPanel, failPanel, joystickPanel;
    [SerializeField] private TextMeshProUGUI woodText, stoneText, goldText;

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
        EventManager.Instance.onUpdateUICollectableType += OnUpdateCollectableType;
    }

    private void UnsubscribeEvents()
    {
        EventManager.Instance.onPlay -= OnOpenJoystickPanel;
        EventManager.Instance.onPlay -= OnCloseStartPanel;
        EventManager.Instance.onUpdateUICollectableType -= OnUpdateCollectableType;
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

    public void OnUpdateCollectableType(CollectableTypes type, int value)
    {
        switch (type)
        {
            case CollectableTypes.Wood:
                {
                    woodText.text = value.ToString();
                    break;
                }
            case CollectableTypes.Stone:
                {
                    stoneText.text = value.ToString();
                    break;
                }
            case CollectableTypes.Gold:
                {
                    goldText.text = value.ToString();
                    break;
                }
        }
    }

}

using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    #region Singleton

    public static EventManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    #endregion

    public UnityAction<HorizontalnputParams> onInputDragged = delegate { };
    public UnityAction onInputReleased = delegate { };
    public UnityEvent onInputTaken;

    public UnityAction onReset = delegate { };
    public UnityAction onPlay = delegate { };

}

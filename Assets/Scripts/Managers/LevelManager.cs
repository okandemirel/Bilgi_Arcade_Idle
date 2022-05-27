using DG.Tweening;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Singleton

    public static LevelManager Instance;

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

    #region Self Variables

    #region Serialized Variables

    [Header("Holder")] [SerializeField] private GameObject levelHolder;

    [Space] [SerializeField] private int totalLevelCount;
    [SerializeField] private int LevelID;

    #endregion

    #endregion

    private void Start()
    {
        EventManager.Instance.onLevelInitialize += OnLevelInitialize;
        EventManager.Instance.onClearActiveLevel += OnClearActiveLevel;
        EventManager.Instance.onNextLevel += OnNextLevel;
        EventManager.Instance.onRestartLevel += OnRestartLevel;


        LevelID = GetLevelID();
        EventManager.Instance.onLevelInitialize?.Invoke(LevelID);
    }

    private void OnDisable()
    {
        EventManager.Instance.onLevelInitialize -= OnLevelInitialize;
        EventManager.Instance.onClearActiveLevel -= OnClearActiveLevel;
        EventManager.Instance.onNextLevel -= OnNextLevel;
        EventManager.Instance.onRestartLevel -= OnRestartLevel;
    }

    private int GetLevelID()
    {
        //if (ES3.FileExists())
        //    if (ES3.KeyExists("Level"))
        //    {
        //        return ES3.Load<int>("Level") % totalLevelCount;
        //    }

        return 0;
    }


    private void OnNextLevel()
    {
        LevelID++;
        EventManager.Instance.onClearActiveLevel?.Invoke();
        DOVirtual.DelayedCall(.1f, () => EventManager.Instance.onLevelInitialize?.Invoke(GetLevelID()));
        //EventManager.Instance.onSaveGameData?.Invoke(new GameSaveDataParams()
        //{
        //    Level = LevelID
        //});
    }

    private void OnRestartLevel()
    {
        EventManager.Instance.onClearActiveLevel?.Invoke();
        DOVirtual.DelayedCall(.1f, () => EventManager.Instance.onLevelInitialize?.Invoke(GetLevelID()));
        //EventManager.Instance.onSaveGameData?.Invoke(new GameSaveDataParams()
        //{
        //    Level = LevelID
        //});
    }

    private void OnLevelInitialize(int levelID)
    {
        var newLevelObject = Resources.Load<GameObject>($"Prefabs/LevelPrefabs/level {levelID}");
        var newLevel = Instantiate(newLevelObject, Vector3.zero, Quaternion.identity);
        if (newLevel != null) newLevel.transform.SetParent(levelHolder.transform);
    }

    private void OnClearActiveLevel()
    {
        Destroy(levelHolder.transform.GetChild(0).gameObject);
    }
}
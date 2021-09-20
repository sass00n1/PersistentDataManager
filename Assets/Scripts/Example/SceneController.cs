using UnityEngine;
using System.Collections;
using SFTool;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SceneTransition()
    {
        StartCoroutine(I_SceneTransition());
    }

    IEnumerator I_SceneTransition()
    {
        //持久化
        PersistentDataManager.SaveAllData();
        PersistentDataManager.ClearPersisters();

        //切换场景
        yield return SceneManager.LoadSceneAsync("Level2");

        //持久化
        PersistentDataManager.LoadAllData();
    }
}

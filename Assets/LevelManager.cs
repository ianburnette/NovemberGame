using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    #region PrivateVariables
    [SerializeField] int currentScene;
#endregion
#region PublicProperties

#endregion
#region UnityFunctions
void Start () {
        DontDestroyOnLoad(gameObject);
}
void Update () {
        GetMyInput();
}
#endregion
#region CustomFunctions
    void GetMyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            LoadScene(1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            LoadScene(2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            LoadScene(3);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            LoadScene(0);
    }

    public void LoadScene(int sceneToLoad)
    {
        SceneManager.UnloadSceneAsync(currentScene);
        currentScene = sceneToLoad;
        SceneManager.LoadSceneAsync(sceneToLoad);
    }
#endregion
}

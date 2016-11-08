using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCorrection : MonoBehaviour {
    
    void Start() {
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.activeSceneChanged += LevelGotLoaded;
    }

    void OnDisable()
    {
        SceneManager.activeSceneChanged -= LevelGotLoaded;
    }

    void LevelGotLoaded(Scene prevScene, Scene newScene)
    {
        GameObject gm = GameObject.Find("gm");
        if (gm == null)
        {
           // print("loading " + newScene.buildIndex + " from " + prevScene.buildIndex);
            int currentScene = newScene.buildIndex;// = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(0);
            // gm = GameObject.Find("gm");
            LevelManager.publicLevelMan.LoadScene(currentScene);
            //publicLevelMan.LoadScene(currentScene);
           // gm.GetComponent<LevelManager>().LoadScene(currentScene);
            //Destroy(gameObject);
        }

    }
 
}
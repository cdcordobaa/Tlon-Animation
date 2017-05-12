using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    public static AsyncOperation loadAsync;

    // Use this for initialization
    void Start()
    {
        //myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/scenes");
        //scenePaths = myLoadedAssetBundle.GetAllScenePaths();
        Scene scene = SceneManager.GetActiveScene();
        int index = scene.buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        loadAsync = SceneManager.LoadSceneAsync((index+1)%totalScenes, LoadSceneMode.Single);
        loadAsync.allowSceneActivation = false;

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Change scene"))
        {
            Debug.Log("scene2 loading: " + 1);
            if (loadAsync.progress > 0.88f)
            {
                Debug.Log("Scene loaded");                
                loadAsync.allowSceneActivation = true;

            }

        }
    }

    

    void Update()
    {

        

        Debug.Log(loadAsync.progress);
        Debug.Log(loadAsync.isDone);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;


public class ScenesManager : MonoBehaviour
{
    public Scene DanceScene;
    public Scene WeaponsScene;
    
    
    public void Initialize()
    {
        
    }

    public void ChangeOnLoadedWeaponScene(bool loaded)
    {
        switch (loaded)
        {
            case true: Debug.Log("WeaponsScene Loaded");
                CustomValues.WeaponsSceneLoaded = true;
                break;
            case false: Debug.Log("WeaponsScene No Loaded");
                CustomValues.WeaponsSceneLoaded = false;
                break;
        }
    }
    
    AsyncOperation asyncLoadLevel;

    public void LoadNeededAdditiveScenes()
    {
        SceneManager.LoadScene("DanceScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("WeaponsScene", LoadSceneMode.Additive);
    }

    private void Update()
    {
        
    }

    IEnumerator LoadScene()
    {
        yield return null;

        //Begin to load the Scene you specify
        asyncLoadLevel = SceneManager.LoadSceneAsync("WeaponsScene",LoadSceneMode.Additive);
        //Don't let the Scene activate until you allow it to
        asyncLoadLevel.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncLoadLevel.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncLoadLevel.isDone)
        {
            //Output the current progress
            

            // Check if the load has finished
            if (asyncLoadLevel.progress >= 0.9f)
            {
                asyncLoadLevel.allowSceneActivation = true;
                
                //Change the Text to show the Scene is ready
                //Wait to you press the space key to activate the Scene
                 ChangeOnLoadedWeaponScene(true);
                if (Input.GetKeyDown(KeyCode.Space))
                    //Activate the Scene
                    asyncLoadLevel.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}

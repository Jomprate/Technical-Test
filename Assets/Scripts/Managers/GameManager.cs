using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    #region Global Data

    [SerializeField, Range(0, 50)] private float baseSpeedRot;
    public static float BaseSpeedRot;

    [SerializeField] private bool OpenScenes;
    [SerializeField] private bool isLoaded;
    
    [SerializeField] private ScenesManager scenesManager;
    private DanceScenePackS _danceScenePackS;
    private WeaponsScenePackS _weaponsScenePackS;

    #endregion
    
    
    
    

    private void Awake()
    {
        instance = this;
        
        
        isLoaded = false;
        if (OpenScenes)
        {
            scenesManager.LoadNeededAdditiveScenes();
        }
        
        CustomValues.WeaponsSceneLoaded = false;
        BaseSpeedRot = baseSpeedRot;
        instance = this;
        
        
        
        GameEvents.Current.OnGameStateChange += ChangeGameState;
        
        
    }

    public void ReturnToAnimState()
    {
        ChangeGameState(Enums.GameState.DanceScene);
    }

    private void Update()
    {
        if (OpenScenes)
        {
            if (_danceScenePackS == null || _weaponsScenePackS == null )
            {
                if (DanceScenePackS.instance != null && WeaponsScenePackS.Instance != null)
                {
                    _danceScenePackS = DanceScenePackS.instance;
                    _weaponsScenePackS = WeaponsScenePackS.Instance;
                    Debug.Log("loaded");
                    isLoaded = true;
                }
                else
                {
                    Debug.Log("Not LOaded");
                }
            
            }
            else
            {
                Debug.Log("loaded all");
            }
        }

        if (isLoaded)
        {
            ChangeGameState(Enums.GameState.Initialization);
            enabled = false;
        }
        
       
    }
    
    
     
    
    private void CheckStateOfLoadedWeaponScene()
    {
        switch (CustomValues.WeaponsSceneLoaded)
        {
            case true: 
                Debug.Log("started");
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("WeaponsScene"));
                GameObject.Find("Main Camera 2"). SetActive(false);
                break;
            case false:
                break;
        }
    }
    
    public void ChangeGameState(Enums.GameState gameState)
    {
        switch (gameState)
        {
            case Enums.GameState.Initialization:
                InputManager.Awake();
                //_scenesManager.Initialize();
                InputManager.PlayerInputs.Player.BackAnim.performed += ctx => ChangeGameState(Enums.GameState.DanceScene);;
                // _allDataContainer.changeCurrentAnimation.Initialize();
                //_allDataContainer.buttonsManager.Initialize(_allDataContainer.changeCurrentAnimation);
                //_robotShoot.Initialize();
                ChangeGameState(Enums.GameState.DanceScene);
                break;
            case Enums.GameState.DanceScene:
                _weaponsScenePackS.ShowCanvas(false);
                _danceScenePackS.ShowCanvas(true);
                _weaponsScenePackS.ShowSceneObjects(false);
                _danceScenePackS.ShowSceneObjects(true);
                _weaponsScenePackS.OthersState(false);
                _danceScenePackS.OthersState(true);
                LookWithMouse.CursorState(false);
                
                
                break;
            case Enums.GameState.WeaponsScene:
                _weaponsScenePackS.ShowCanvas(true);
                _danceScenePackS.ShowCanvas(false);
                _weaponsScenePackS.ShowSceneObjects(true);
                
                _danceScenePackS.OthersState(false);
                _weaponsScenePackS.OthersState(true);
                LookWithMouse.CursorState(true);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }
    }
    

}

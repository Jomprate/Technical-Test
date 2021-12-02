using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class DanceScenePackS : MonoBehaviour
{
    public static DanceScenePackS instance;
    [SerializeField] private ManagerS1 _managerS1;
    [SerializeField] private Canvas bigCanvasS1;
    [SerializeField] private GameObject sceneObjects;
    [SerializeField] private GameObject[] others;

    private void Awake()
    {
        instance = this;
        // _managerS1.Awake();
        _managerS1.ShowText();
    }

    public void ShowCanvas(bool show)
    {
        switch (show)
        {
            case true: bigCanvasS1.gameObject.SetActive(true);
                break;
            case false: bigCanvasS1.gameObject.SetActive(false);
                break;
        }
    }

    public void OthersState(bool show)
    {
        switch (show)
        {
            case true: foreach (var go in others) { go.gameObject.SetActive(true); }
                break;
            case false: foreach (var go in others) { go.gameObject.SetActive(false); }
                break;
        }
    }

    public void ShowSceneObjects(bool show)
    {
        switch (show)
        {
            case true: sceneObjects.gameObject.SetActive(true);
                break;
            case false: sceneObjects.gameObject.SetActive(false);
                break;
        }
    }
    
}

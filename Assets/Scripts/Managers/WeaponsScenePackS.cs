using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class WeaponsScenePackS : MonoBehaviour
{
    public static WeaponsScenePackS Instance;
    [SerializeField] private ManagerS2 _managerS2;
    [SerializeField] private Canvas bigCanvasS2;
    [SerializeField] private GameObject sceneObjects;
    [SerializeField] private GameObject[] others;
    private void Awake()
    {
        Instance = this;
        
    }
    
    public void ShowCanvas(bool show) {
        switch (show) {
            case true: bigCanvasS2.gameObject.SetActive(true); break;
            case false: bigCanvasS2.gameObject.SetActive(false); break;
        }
    }
    public void OthersState(bool show) {
        switch (show) {
            case true: foreach (var go in others) { go.gameObject.SetActive(true); } break;
            case false: foreach (var go in others) { go.gameObject.SetActive(false); } break;
        }
    }
    public void ShowSceneObjects(bool show)
    {
        switch (show) {
            case true: sceneObjects.gameObject.SetActive(true); break;
            case false: sceneObjects.gameObject.SetActive(false); break;
        }
    }
}

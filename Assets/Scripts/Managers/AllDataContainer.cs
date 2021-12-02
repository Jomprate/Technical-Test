using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[DefaultExecutionOrder(-100)]
public class AllDataContainer : MonoBehaviour
{
    public static AllDataContainer Instance;
    [Header("Scripts in game")] 
    public ChangeCurrentAnimation changeCurrentAnimation;
    public ButtonsManager buttonsManager;
    public ObjectPooler objectPooler;
    [Header("Needed")]
    [SerializeField] private GameObject animButtonsParent;
    [SerializeField] private GameObject selectorPanel;
    [SerializeField] private GameObject player;
    [SerializeField] public GameObject bulletsContainer;
    
    [HideInInspector] public Button[] animButtons;
    [HideInInspector] public Button selectButton;
    [SerializeField] public Animator animator;
    public List<Image> buttonSelectionImagesL;

    [SerializeField] public GameObject[] ObjectsToTurnS1;
    [SerializeField] public GameObject[] ObjectsToTurnS2;
    public GameObject camera2;
    

    private void Awake() => Instance = this;

    public void GetNeeded()
    {
        animButtons = animButtonsParent.transform.GetComponentsInChildren<Button>();
        selectButton = selectorPanel.transform.GetChild(0).GetComponent<Button>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = player.GetComponent<Animator>();

        foreach (var button in animButtons)
        {
           buttonSelectionImagesL.Add( button.gameObject.transform.GetChild(1).GetComponent<Image>());
        }
    }

    public void ClearData()
    {
        animButtons = null;
        selectButton = null;
    }
}

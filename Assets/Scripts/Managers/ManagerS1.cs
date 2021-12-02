using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class ManagerS1 : MonoBehaviour
    {
        public static ManagerS1 instance;
        [SerializeField, Range(0, 50)] private float baseSpeedRot;
        public static float BaseSpeedRot;

        [SerializeField] private ChangeCurrentAnimation changeCurrentAnimation;
        [SerializeField] private ButtonsManager buttonsManager;
    
        [Header("Needed")]
         public Button[] animButtons;
        [SerializeField] public Button selectButton;
        [SerializeField] public Animator animator;
        public List<Image> buttonSelectionImagesL;
        [SerializeField] private Button selectedButton;
        
    
        [SerializeField] private GameObject animButtonsParent;
        [SerializeField] private GameObject selectorPanel;
        [SerializeField] private GameObject player;
    

        public void Awake()
        {
            instance = this;
            BaseSpeedRot = baseSpeedRot;
            SetNeeded();
            ChangeGameState(Enums.StateAnimScene.Initialization);
            BaseSpeedRot = baseSpeedRot;
        }

        public void ShowText()
        {
            Debug.Log("CanStart M1");
        }
        
        public void SetNeeded()
        {
            
            animButtons = animButtonsParent.transform.GetComponentsInChildren<Button>();
            selectButton = selectorPanel.transform.GetChild(0).GetComponent<Button>();
            player = GameObject.FindGameObjectWithTag("Player");
            animator = player.GetComponent<Animator>();
            changeCurrentAnimation = FindObjectOfType<ChangeCurrentAnimation>();
            buttonsManager = FindObjectOfType<ButtonsManager>();
            foreach (var button in animButtons)
            {
                buttonSelectionImagesL.Add( button.gameObject.transform.GetChild(1).GetComponent<Image>());
            }
        }

        public void ClearData()
        {
            buttonSelectionImagesL.Clear();
        }
    
        private void ChangeGameState(Enums.StateAnimScene gameState)
        {
            switch (gameState)
            {
                case Enums.StateAnimScene.Initialization:
                    InputManager.Awake();
                    changeCurrentAnimation.Initialize(animator);
                    buttonsManager.Initialize(changeCurrentAnimation,animButtons,buttonSelectionImagesL,selectButton);
                
                
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
            }
        }
    
    }
}

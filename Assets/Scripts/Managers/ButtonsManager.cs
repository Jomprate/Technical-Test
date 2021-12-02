using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// ReSharper disable ParameterHidesMember

public class ButtonsManager : MonoBehaviour
{
    
    public ChangeCurrentAnimation changeCurrentAnimation;
    private Button[] animButtons;
    private Button selectedButton;
    public List<Image> buttonSelectionImagesL;
    private GameManager _gameManager;
    
    

    public void Initialize(ChangeCurrentAnimation changeCurrentAnimationS,Button[] animButtons,
        List<Image> buttonSelectionImagesL,Button selectedButton)
    {
        CustomValues.SelectedAnimation = 3;
        
        _gameManager = GameManager.instance;
        this.selectedButton = selectedButton;
        this.changeCurrentAnimation = changeCurrentAnimationS;
        this.animButtons = animButtons;
        this.buttonSelectionImagesL = buttonSelectionImagesL;
        SetNeeded();
        
        
        SetAllUnSelected();
       
    }
    public void SetNeeded()
    {
        selectedButton.interactable = false;
        SetVoidsToButtons();
    }
    
    public  void SelectAnimation(int animationNumber)
    {
        switch (animationNumber)
        {
            case 0: changeCurrentAnimation.ChangeSelectedAnimation(Enums.SelectedAnimation.Animation0);
                SetSelectedButtonImage(0);
                selectedButton.interactable = true;
                CustomValues.SelectedAnimation = 0;
                
                break;
            case 1: changeCurrentAnimation.ChangeSelectedAnimation(Enums.SelectedAnimation.Animation1);
                SetSelectedButtonImage(1);
                selectedButton.interactable = true;
                CustomValues.SelectedAnimation = 1;
                
                break;
            case 2: changeCurrentAnimation.ChangeSelectedAnimation(Enums.SelectedAnimation.Animation2);
                SetSelectedButtonImage(2);
                selectedButton.interactable = true;
                CustomValues.SelectedAnimation = 2;
                
                break;
            case 3: changeCurrentAnimation.ChangeSelectedAnimation(Enums.SelectedAnimation.Animation3);
                SetAllUnSelected();
                break;
        }
    }

    

    private void SetVoidsToButtons()
    {
        animButtons[0].onClick.AddListener(delegate { SelectAnimation(0); });
        
        animButtons[1].onClick.AddListener(delegate { SelectAnimation(1); });
        
        animButtons[2].onClick.AddListener(delegate { SelectAnimation(2); });
        
        selectedButton.onClick.AddListener(delegate { _gameManager.ChangeGameState(Enums.GameState.WeaponsScene);});

    }

    #region Buttons Images Control

    private void SetSelectedButtonImage(int imageId) {
        switch (imageId) {
            case 0: SetAllUnSelected();
                buttonSelectionImagesL[0].color = CustomValues.AnimSelectedColor; break;
            case 1: SetAllUnSelected();
                buttonSelectionImagesL[1].color = CustomValues.AnimSelectedColor; break;
            case 2: SetAllUnSelected();
                buttonSelectionImagesL[2].color = CustomValues.AnimSelectedColor; break;
        }
    }
    
    private void SetAllUnSelected() {
        foreach (var image in buttonSelectionImagesL) {
            image.color = CustomValues.AnimUnSelectedColor; }
    }
    #endregion
}

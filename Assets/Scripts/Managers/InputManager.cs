using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-100)]
 public static class InputManager
{
    public static bool SideGunsActive; //Is used

    public static InputMaster UI_Inputs;
    public static InputMaster PlayerInputs;
    public static InputMaster ConnectorInputs;
    public static InputMaster NumpadInputs;

    public static float NumpadValue;
    
    public static bool PlayerInputsActive;
    


    public static void Awake()
    {
        
        PlayerInputs = new InputMaster();
        UI_Inputs = new InputMaster();
        ConnectorInputs = new InputMaster();
        NumpadInputs = new InputMaster();
        
        
        EnablePlayerInputs();
        EnableConnectorInputs();
        EnableNumpadInputs();
        
    }

    

    public static void EnablePlayerInputs()
    {
        PlayerInputs.Enable();
        PlayerInputsActive = true;
    }

    public static void DisablePlayerInputs()
    {
        PlayerInputs.Disable();
        PlayerInputsActive = false;
    }

    public static void EnableUIInputs()
    {
        UI_Inputs.Enable();
    }

    public static void DisableUIInputs()
    {
        UI_Inputs.Disable();
    }

    public static void EnableConnectorInputs()
    {
        ConnectorInputs.Enable();   
    }

    public static void DisableConnectorInputs()
    {
        ConnectorInputs.Disable();   
    }

    private static void EnableNumpadInputs()
    {
        NumpadInputs.Enable();
    }
    
    private static void DisableNumpadInputs()
    {
        NumpadInputs.Disable();
    }


}

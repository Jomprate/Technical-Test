using System;
using UnityEngine;
[DefaultExecutionOrder(-99)]
public class GameEvents : MonoBehaviour
{
    public static GameEvents Current;

    public void Awake()
    {
        Current = this;
        
        ChangeSelectedAnimationE();
        ChangePlayerMovementUpdate();
        ChangeOnLoadedWeaponsScene();
        
    }

    public event Action<Enums.GameState> OnGameStateChange;
    public event Action<Enums.SelectedAnimation> OnSelectedAnimationChange;
    public event Action<bool> OnLoadedWeaponsScene; 
    public event Action<bool> OnPlayerMovementState;

    
    
    private void ChangeSelectedAnimationE() {
        OnSelectedAnimationChange?.Invoke(Enums.SelectedAnimation.Animation3);
    }

    private void ChangeGameStateE()
    {
        OnGameStateChange?.Invoke(Enums.GameState.Initialization);
    }
    
    private void ChangePlayerMovementUpdate() {
        OnPlayerMovementState?.Invoke(false);
    }

    private void ChangeOnLoadedWeaponsScene()
    {
        OnLoadedWeaponsScene?.Invoke(false);
    }

    
}

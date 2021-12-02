using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Enums
{
    public enum SelectedAnimation
    {
        Animation0 = 0,
        Animation1 = 1,
        Animation2 = 2,
        Animation3 = 3
        
    }

    public enum SelectedProjectile
    {
        ParabolicProjectile = 0,
        OrbiterProjectile = 1,
        ExplosiveProjectile = 2,
        NonProjectileSelected = 3
    }

    public enum StateAnimScene
    {
        Initialization,
        
    }
    
    public enum StateWeaponsScene
    {
        Initialization,
        Weapon1,
        Weapon2,
        Weapon3,
        ReturnTo1
    }
    
    
    public enum GameState
    {
        Initialization,
        DanceScene,
        WeaponsScene
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using UnityEngine;
using Random = System.Random;
using System.IO;
// ReSharper disable All



[DefaultExecutionOrder(-110)]
public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; set; }
    public SaveState state;
    public static string hashKey;

    public bool ResetSave = false;

    public bool FirstLoad = true;


    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        //DontDestroyOnLoad(this.gameObject);
        
        Instance = this;
        if (ResetSave)
        {
            ResetSaveData();
        }
        
        
        Load();
        Debug.Log (state.Serialize<SaveState>());

        // state.Hacks = 10;
        // SaveManager.Instance = this;
        // ResetSaveData();
        // Save();
        //
        //
        //
        //
        // Debug.Log (state.Serialize<SaveState>());
        // //Load();
        // //LockDoor(1001);
        // Save();
        // Load();
    }

    

    #region Save & Load
    //Save The Game
    public void Save()
    {
        if (FirstLoad)
        {
            //DontUseObf();
            //PlayerPrefs.SetString("Save",Helper.Encrypt(Helper.Serialize<SaveState>(state)));
            PlayerPrefs.SetString("Save",Helper.Serialize<SaveState>(state));
        }
        else
        {
            //PlayerPrefs.SetString("Save",Helper.Encrypt(Helper.Serialize<SaveState>(state)));
            PlayerPrefs.SetString("Save",Helper.Serialize<SaveState>(state));
        }
        
        // //PlayerPrefs.SetString("Save",Helper.Encrypt(Helper.Serialize<SaveState>(state)));
        // PlayerPrefs.SetString("Save",Helper.Serialize<SaveState>(state));
        
        
    }
    
    //Load The Game
    public void Load()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            //state = Helper.Deserialize<SaveState>(Helper.Decrypt( PlayerPrefs.GetString("Save")));
            
            state = Helper.Deserialize<SaveState>( PlayerPrefs.GetString("Save"));
            
        }
        else
        {
            state = new SaveState();
            //SaveManager.Instance.state.Hacks = (int)SC_Obf.Obfuscate(0);
            
            //DontUseObf();
            if (FirstLoad)
            {
                Save();
                FirstLoad = false;
            }
            else
            {
                
                Save();
                //UseObf();
            }
           
            
            Debug.Log("No save file found, creating a new one");
        }
        
    }
    #endregion

    // public void UseObf()
    // {
    //     SaveManager.Instance.state.Hacks = (int)SC_Obf.Obfuscate(SaveManager.Instance.state.Hacks);
    // }
    //
    // public void DontUseObf()
    // {
    //     //SaveManager.Instance.state.Hacks = (int)SC_Obf.Obfuscate(SaveManager.Instance.state.Hacks);
    //     SaveManager.Instance.state.Hacks = (int)SC_Obf.DeObfuscate(SaveManager.Instance.state.Hacks);
    // }

    public int GetParabolicProjectileQ() {
        return state.ParabolicProjectile; }
    public int GetOrbiterProjectileQ() {
        return state.OrbiterProjectile; }
    public int GetExplosiveProjectileQ() {
        return state.ExplosiveProjectile; }

    #region Add Bullets

    public void AddParabolicProjectile(int quantity)
    {
        state.ParabolicProjectile += quantity;
        //Save();
    }

    public void SubstractParabolicProjectiles(int quantity)
    {
        state.ParabolicProjectile -= quantity;
        //Save();
    }

    public void AddOrbitterProjectiles(int quantity)
    {
        state.OrbiterProjectile += quantity;
        Save();
    }
    
    public void SubstractOrbiterProjectiles(int quantity)
    {
        state.OrbiterProjectile -= quantity;
        // Save();
    }
    
    public void ModifyOrbiterProjectileQ(bool add,int quantity)
    {
        state.OrbiterProjectile = add switch
        {
            true => state.OrbiterProjectile -= quantity,
            false=> state.OrbiterProjectile += quantity
        };
        //Save();
    }
    public void AddExplosiveProjectiles(int quantity)
    {
        state.ExplosiveProjectile += quantity;
        Save();
    }
    
    public void SubstractExplosiveProjectiles(int quantity)
    {
        state.ExplosiveProjectile -= quantity;
        // Save();
    }
    
    public void ModifyExplosiveProjectileQ(bool add,int quantity)
    {
        state.ExplosiveProjectile = add switch
        {
            true => state.ExplosiveProjectile -= quantity,
            false => state.ExplosiveProjectile += quantity
        };
        //Save();
    }
    

    #endregion

    
    
    
    

    //Reset all Save Data
    public void ResetSaveData()
    {
        PlayerPrefs.DeleteKey("Save");
    }
    
    
}

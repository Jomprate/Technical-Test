using UnityEngine;

public static class SC_Obf 
{
    static int _random = -1;
    private static bool randomSet;
    

    public static void Initialize()
    {
        if(_random == -1)
        {
            _random = Random.Range(1000000, 9999999);
        }
        
        Debug.Log("The current Random Value is : " + _random);
    }

    public static int GetRandomValue()
    {
        return _random;
    }

    public static void SetRandom(int random)
    {
        _random = random;
        //_random = XMLConfigSaves.Instance.SpecialItemDB.specialItemsList[0].intValue;
    }

    public static float Obfuscate(float originalValue)
    {
        return _random - originalValue;
    }

    public static float DeObfuscate(float obfuscatedValue)
    {
        
        return _random - obfuscatedValue;
    }
}

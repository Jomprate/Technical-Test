using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = System.Random;


public static class StringCreator
{
    private static string letras;


    public static string Main()
    {
        int asciiCharacterStart = 65; // from which ascii character code the generation should start
        int asciiCharacterEnd = 122; // to which ascii character code the generation should end
        int characterCount = 100; // count of characters to generate
            
        Random random = new Random(DateTime.Now.Millisecond);
        StringBuilder builder = new StringBuilder();
            
        // iterate, get random int between 'asciiCharacterStart' and 'asciiCharacterEnd', then convert it to (char), append to StringBuilder
        for (int i = 0; i < characterCount; i++)
            builder.Append((char)(random.Next(asciiCharacterStart, asciiCharacterEnd + 1) % 255));

        // voila!
        letras = builder.ToString();
        
        Debug.Log(letras);
        return letras;
    }
    
}

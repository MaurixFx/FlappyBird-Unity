using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // This is to have this option in Unity menu 
public class CharacterDatabase: ScriptableObject
{
    public Character[] character;

    public int characterCount
    {
        get
        {
            return character.Length;
        }
    }

    public Character GetCharacter(int index)
    {
        return character[index];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public CharacterDatabase characterDB;

    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("characterSelectedOption");
        GameObject prefab = characterDB.GetCharacter(selectedCharacter).characterSprite;
        prefab.SetActive(true);
        Instantiate(prefab, transform.position, transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedOption = 0;

    public void NextOption()
    {
        characters[selectedOption].SetActive(false);
        selectedOption++;

        if (selectedOption >= characters.Length)
        {
            selectedOption = 0;
        }

        characters[selectedOption].SetActive(true);
    }

    public void BackOption()
    {
        characters[selectedOption].SetActive(false);
        selectedOption--;

        if(selectedOption < 0)
        {
            selectedOption = characters.Length - 1;
        }

        characters[selectedOption].SetActive(true);
    }

    private void Save()
    {
        PlayerPrefs.SetInt("characterSelectedOption", selectedOption);
    }

    public void StartGame(int sceneID)
    {
        Save();
        SceneManager.LoadScene(sceneID); // Load the scene per id Int
    }
}

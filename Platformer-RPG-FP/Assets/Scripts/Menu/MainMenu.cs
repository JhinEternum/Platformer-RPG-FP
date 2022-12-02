using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;

    public void PlayGame()
    {
        if (nameInput.text.Length == 0) return;

        PersistentData.Instance.currentName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

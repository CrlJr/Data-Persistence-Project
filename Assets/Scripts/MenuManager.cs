using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public TMP_InputField inputField;
    private string inputFieldText;

    public void StartGame()
    {
        inputFieldText = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }

}

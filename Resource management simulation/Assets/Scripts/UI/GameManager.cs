using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OpenMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}

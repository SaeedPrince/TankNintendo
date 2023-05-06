using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	void Start ()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartMyGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitMyGame()
    {
        Application.Quit();
    }

}

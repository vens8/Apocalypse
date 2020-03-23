using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Mainmenu : MonoBehaviour
{
    public TextMeshProUGUI Error;
    private void Start()
    {
        if(DBManager.LoggedIn)
        {
            Error.text = "Login Sucess!"+"\nPlayer: " + DBManager.username ;
        }
    }

    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToLogin()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(3);
    }
}

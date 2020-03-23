using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField userNameField;
    public InputField passwordField;
    public TextMeshProUGUI Error;
    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", userNameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;

        if(www.text[0]=='0')
        {
            DBManager.username = userNameField.text;
            DBManager.MedicXP = int.Parse(www.text.Split('\t')[1]);
            DBManager.InfectedXP = int.Parse(www.text.Split('\t')[2]);
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }

        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = false;
        if (userNameField.text.Length < 3)
        {
            Error.text = "Username must contain at least 3 characters.";
        }
        else if (passwordField.text.Length < 8)
        {
            Error.text = "Password must contain at least 8 characters.";
        }
        else
        {
            Error.text = "";
            submitButton.interactable = true;
        }
    }
}

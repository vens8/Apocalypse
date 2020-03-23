using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Registration : MonoBehaviour
{
    public InputField userNameField;
    public InputField passwordField;
    public InputField repasswordField;
    public TextMeshProUGUI UMessage;
    public TextMeshProUGUI PMessage1;
    public TextMeshProUGUI PMessage2;
    public TextMeshProUGUI Error;
    public Button submitButton;

    public void CallRegister()
    {
            StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", userNameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User created successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
            
            if (www.text == "3: Username already exists")
            {
                Error.text = "Username is already taken. Please try using another one.";
            }
            else
            {
                Error.text = "Could not connect to server";
            }
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = false;
         if(userNameField.text.Length < 3)
        {
            Error.text = "Username must contain at least 3 characters.";
        }
         else if(passwordField.text.Length < 8)
        {
            Error.text = "Password must contain at least 8 characters.";
        }
         else if(repasswordField.text != passwordField.text)
        {
            Error.text = "Passwords don't match.";
        }
        else
        {
            Error.text = "";
            submitButton.interactable = true;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System.Threading;
using System;

public class Login : MonoBehaviour 
{
	//登入
	public InputField inputUsername;
	public InputField inputPassword;

	private string Loginsuccess = "success";

	string LoginURL = "http://localhost/Cool_YT_RPG/Login.php";

	IEnumerator LoginToDB(string username,string password)
	{
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("passwordPost", password);
		WWW www = new WWW(LoginURL, form);
		yield return www;

		//Debug.Log (www.text);
        
        if (www.text=="success")
		{
			SceneManager.LoadScene ("Game");
            Debug.Log("正確密碼");
        } 
		else 
        {
			Debug.Log ("錯誤密碼");
		}

	}
	public void SubmitBtn() 
	{
		StartCoroutine(LoginToDB(inputUsername.text, inputPassword.text));
        Database.user = inputUsername.text;


    }
	public void GoRegister()
	{
		SceneManager.LoadScene ("Register");

	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DataInserter : MonoBehaviour
{
	//註冊把資料弄到資料庫
	public InputField inputUserName;
	public InputField inputPassword;
	public InputField inputEmail;

	string CreateUserURL = "http://localhost/Cool_YT_RPG/InsertUser.php";

	public void CreateUser(string username, string password, string email)
	{
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("passwordPost", password);
		form.AddField("emailPost", email);
		WWW www = new WWW(CreateUserURL, form);
	}
	public void RegisterBtn()
	{
		if (inputUserName.text.Length >= 4 && inputPassword.text.Length >= 6 && inputEmail.text.Length >= 8) {
			CreateUser (inputUserName.text, inputPassword.text, inputEmail.text);
			SceneManager.LoadScene ("Menu");
		}
		else 
		{
			Debug.Log ("帳號密碼太短");
		}
	}
	public void BacktoMenu()
	{
	  SceneManager.LoadScene ("Menu");
	}
}

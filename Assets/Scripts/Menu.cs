using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

	public GameObject menuUI;


	public void StartGame()
	{
		PlayerPrefs.SetInt("level", 0);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Quit()
	{
		Application.Quit();
	}

}
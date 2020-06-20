using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

	public int levelsComplete;


	void Start()
	{
		levelsComplete = PlayerPrefs.GetInt("level");
	}

	public void LoadNextLevel()
	{
		if (SceneManager.sceneCount <= SceneManager.GetActiveScene().buildIndex + 1) 
		{
			SceneManager.LoadScene("Menu");
		}
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		PlayerPrefs.SetInt("level", levelsComplete + 1);
	}


}

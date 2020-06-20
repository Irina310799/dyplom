using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

	bool gameHasEnded = false;

	public float restartDelay = 1f;
	public GameObject completeLevelUI;
	public GameObject startLevelUI;
	public Text levelText;
	public PlayerMovement movement;

	private int playerLevel = 1;

	public static int currentResolutionIndex = 0;

	void Start()
	{
		levelText.text = "Player Level: " + playerLevel.ToString();
		startLevelUI.SetActive(true);

	}

	void addLevel()
	{
		playerLevel = playerLevel + 1;
	}

	public int getPlayerLevel()
	{
		return this.playerLevel;
	}

	public void setPlayerLevel(int playerLevel)
	{
		this.playerLevel = playerLevel;
	}


	public void CompleteLevel()
	{
		movement.enabled = false;
		this.addLevel();
		completeLevelUI.SetActive(true);
	}

	public void EndGame()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			Invoke("Restart", restartDelay);
		}

	}

	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}

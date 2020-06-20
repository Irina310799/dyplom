using UnityEngine;

public class FinishTriger : MonoBehaviour
{

	public GameManager gameManager;

	void OnTriggerEnter2D()
	{
		gameManager.CompleteLevel();
	}

}

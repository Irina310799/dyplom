using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTrigger : MonoBehaviour
{
	public GameManager gameManager;
	public GameObject taskUI;

	void OnTriggerEnter2D()
	{
		taskUI.SetActive(true);
	}

	void OnTriggerExit2D()
	{
		taskUI.SetActive(false);
	}
}

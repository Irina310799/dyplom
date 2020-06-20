using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public InputField centerUp;
    public InputField centerDown;
    public InputField centerMid;
    public InputField rightUp;
    public InputField rightMid;
    public InputField rightDown;
    public InputField leftMid;
    public InputField leftDown;
    public InputField leftUp;
    public GameObject taskUI;
    public GameManager gameManager;

    private bool upRowCorrect = false;
    private bool midRowCorrect = false;
    private bool downRowCorrect = false;
    private bool solved = false;
    private bool leftRowCorrect = false;
    private bool centerRowCorrect = false;

    void Update()
    {
        if (this.solved) {
            this.gameManager.CompleteLevel();
            this.taskUI.SetActive(false);
        }
    }

    public void OnLeftUpInput() 
    {
        if ((int.Parse(this.rightUp.placeholder.GetComponent<Text>().text) + int.Parse(this.centerUp.placeholder.GetComponent<Text>().text) + int.Parse(this.leftUp.text)).Equals(15)) 
        {
            this.upRowCorrect = true;
        }
        if (!string.IsNullOrEmpty(this.leftDown.text) && (int.Parse(this.leftMid.placeholder.GetComponent<Text>().text) + int.Parse(this.leftUp.text) + int.Parse(this.leftDown.text)).Equals(15))
        {
            this.leftRowCorrect = true;
        }
        this.isSolved();
    }

    public void OnLeftDownInput()
    {
        if (!string.IsNullOrEmpty(this.centerDown.text) && (int.Parse(this.rightDown.placeholder.GetComponent<Text>().text) + int.Parse(this.centerDown.text) + int.Parse(this.leftDown.text)).Equals(15))
        {
            this.downRowCorrect = true;
        }
        if (!string.IsNullOrEmpty(this.leftUp.text) &&  (int.Parse(this.leftMid.placeholder.GetComponent<Text>().text) + int.Parse(this.leftDown.text) + int.Parse(this.leftUp.text)).Equals(15))
        {
            this.leftRowCorrect = true;
        }
        this.isSolved();
    }

    public void OnCenterMidInput()
    {
        if (!string.IsNullOrEmpty(this.centerDown.text) && (int.Parse(this.centerUp.placeholder.GetComponent<Text>().text) + int.Parse(this.centerDown.text) + int.Parse(this.centerMid.text)).Equals(15))
        {
            this.centerRowCorrect = true;
        }
        if ((int.Parse(this.leftMid.placeholder.GetComponent<Text>().text) + int.Parse(this.centerMid.text) + int.Parse(this.rightMid.placeholder.GetComponent<Text>().text)).Equals(15))
        {
            this.midRowCorrect = true;
        }
        this.isSolved();
    }

    public void OnCenterDownInput()
    {
        if (!string.IsNullOrEmpty(this.leftDown.text) && (int.Parse(this.rightDown.placeholder.GetComponent<Text>().text) + int.Parse(this.leftDown.text) + int.Parse(this.centerDown.text)).Equals(15))
        {
            this.downRowCorrect = true;
        }
        if (!string.IsNullOrEmpty(this.centerMid.text) && (int.Parse(this.centerMid.text) + int.Parse(this.centerDown.text) + int.Parse(this.centerUp.placeholder.GetComponent<Text>().text)).Equals(15))
        {
            this.centerRowCorrect = true;
        }
        this.isSolved();
    }

    private void isSolved() 
    {
        if (this.upRowCorrect && this.centerRowCorrect && this.downRowCorrect && this.leftRowCorrect && this.midRowCorrect)
        {
            this.solved = true;
        }
    }
}

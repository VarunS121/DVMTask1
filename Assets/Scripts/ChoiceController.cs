using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceController : MonoBehaviour
{
    public Image CompChoice;
    public Text Text;
    public Sprite Rock, Paper, Scissors;
    public Text PlayerScore;
    public Text CompScore;
    public GameObject MainIcons;
    public string[] Choices;

    public void Play(string PlayerChoice)
    {
        int playerScore;
        int compScore;
        Debug.Log("Animation Start");
        CompChoice.GetComponent<Animator>().enabled = true;
        CompChoice.GetComponent<Animator>().Play("CompChoice");
        CompChoice.GetComponent<Animator>().enabled = false;
        Debug.Log("Animation Played!");
        string randChoice = Choices[UnityEngine.Random.Range(0, Choices.Length)];

        switch (randChoice)
        {
            case "Rock":
                playerScore = Int32.Parse(PlayerScore.text);
                compScore = Int32.Parse(CompScore.text);
                switch (PlayerChoice)
                {
                    case "Rock":
                        Text.text = "Tie!";
                        break;

                    case "Paper":
                        Text.text = "You get a point!!";
                        playerScore++;
                        PlayerScore.text = playerScore.ToString();
                        break;

                    case "Scissors":
                        Text.text = "Computer gets a point!!";
                        compScore++;
                        CompScore.text = compScore.ToString();
                        break;
                }
                
                CompChoice.sprite = Rock;
                break;
            
            case "Paper":
                playerScore = Int32.Parse(PlayerScore.text);
                compScore = Int32.Parse(CompScore.text);
                switch (PlayerChoice)
                {
                    case "Rock":
                        Text.text = "Computer gets a point!!";
                        compScore++;
                        CompScore.text = compScore.ToString();
                        break;

                    case "Paper":
                        Text.text = "Tie!";
                        break;

                    case "Scissors":
                        Text.text = "You get a point!!";
                        playerScore++;
                        PlayerScore.text = playerScore.ToString();
                        break;
                }
                
                CompChoice.sprite = Paper;
                break;

            case "Scissors":
                playerScore = Int32.Parse(PlayerScore.text);
                compScore = Int32.Parse(CompScore.text);
                switch (PlayerChoice)
                {
                    case "Rock":
                        Text.text = "You get a point!!";
                        playerScore++;
                        PlayerScore.text = playerScore.ToString();
                        break;

                    case "Paper":
                        Text.text = "Computer gets a point!!";
                        compScore++;
                        CompScore.text = compScore.ToString();
                        break;

                    case "Scissors":
                        Text.text = "Tie!";
                        break;
                }

                CompChoice.sprite = Scissors;
                break;
        }
    }

    void Update()
    {
        int playerScore = Int32.Parse(PlayerScore.text);
        int compScore = Int32.Parse(CompScore.text);
        if (playerScore == 5 || compScore == 5)
        {
            if (playerScore == 5)
            {
                Text.text = "YOU WIN!!!";
            } else if (compScore == 5)
            {
                Text.text = "YOU LOSE :(";
            }
            StartCoroutine(waiter());
        }
    } 

    IEnumerator waiter()
    {
        MainIcons.GetComponent<CanvasGroup>().alpha = 0.0f;
        Text.GetComponent<Text>().fontSize = 40;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
    }
}

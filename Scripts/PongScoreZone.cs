using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PongScoreZone : MonoBehaviour {

    public Text playerOneScoreText, playerTwoScoreText;
    public GameObject paddle1, paddle2, ball, dashes;
    [SerializeField]
    private Text victor;
    [SerializeField]
    private GameObject playAgainButton;
    private  int playerOneScore, playerTwoScore;

    private void Start()
    {
        if (PongGameplayController.onePlayer)
            playerTwoScore = int.Parse(playerTwoScoreText.text);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.name == "Ball")
        {
            if (name == "Player 1 Score")
            {
                playerOneScore++;
                playerOneScoreText.text = playerOneScore.ToString();

                if (!PongGameplayController.onePlayer)
                {
                    if (!CheckForVictor())
                    {
                        target.GetComponent<PongBall>().Reset("Player 1 Paddle");
                    }
                }
                else
                {
                    target.GetComponent<PongBall>().Reset("Player 1 Paddle");
                }

            }
            else if (name == "Player 2 Score")
            {
                if (PongGameplayController.onePlayer)
                {
                    playerTwoScore--;
                    if (playerTwoScore < 0)
                    {
                        playerOneScore = int.Parse(playerOneScoreText.text);
                        PongGameplayController.HighScoreCheck(playerOneScore);
                        SceneManager.LoadScene("Pong Game Over Screen");
                    }
                    else
                    {
                        playerTwoScoreText.text = playerTwoScore.ToString();
                        target.GetComponent<PongBall>().Reset("Player 2 Paddle");
                    }
                }
                else 
                { 
                    playerTwoScore++;
                    playerTwoScoreText.text = playerTwoScore.ToString();
                    if (!CheckForVictor()) 
                    {
                        target.GetComponent<PongBall>().Reset("Player 2 Paddle");
                    }

                }              

            }

        }
    }

    public bool CheckForVictor()
    {
        bool gameEnded = false;
        if (playerOneScore >= 3)
        {
            paddle1.SetActive(false);
            paddle2.SetActive(false);
            ball.SetActive(false);
            dashes.SetActive(false);

            playAgainButton.SetActive(true);
            victor.gameObject.SetActive(true);
            victor.text = "PLAYER ONE WINS";
            gameEnded = true;
        }
        else if (playerTwoScore >= 3)
        {
            paddle1.SetActive(false);
            paddle2.SetActive(false);
            ball.SetActive(false);
            dashes.SetActive(false);

            playAgainButton.SetActive(true);
            victor.gameObject.SetActive(true);
            victor.text = "PLAYER TWO WINS";
            gameEnded = true;
        }

        return gameEnded;

    }
}

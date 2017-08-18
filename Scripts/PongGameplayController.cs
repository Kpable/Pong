using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PongGameplayController : MonoBehaviour {

    public static bool onePlayer = true;
    [SerializeField]
    private GameObject ballImage;
    [SerializeField]
    private Text playerLivesText;

    private int startingLives = 3;

	// Use this for initialization
	void Awake () {
        if (!onePlayer)
        {
           if(ballImage) ballImage.SetActive(false);
        }
        else
        {
            if (playerLivesText) playerLivesText.text = startingLives.ToString();
        }
	}


    public static void HighScoreCheck(int score)
    {
        if (PlayerPrefs.GetInt("Pong High Score") < score)
        {
            PlayerPrefs.SetInt("Pong High Score", score);
        }
    }
}

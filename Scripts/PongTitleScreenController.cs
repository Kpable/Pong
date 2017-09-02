using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PongTitleScreenController : MonoBehaviour {

    [SerializeField]
    private GameObject onePlayer, twoPlayer, playButton, pcInstructions, mobileInstructions;

    [SerializeField]
    private Text highScore;
    public void Start()
    {
        if(highScore) highScore.text = "High Score \n" + PlayerPrefs.GetInt("Pong High Score");
    }
    public void PlayOnePlayer()
    {
        SceneManager.LoadScene("Pong Gameplay");
    }
    public void PlayTwoPlayer()
    {
        PongGameplayController.onePlayer = false;
        SceneManager.LoadScene("Pong Gameplay");
    }
    public void PlayerNumberSelect()
    {
        onePlayer.SetActive(true);
        twoPlayer.SetActive(true);
        playButton.SetActive(false);

        if(Application.isMobilePlatform)
        {
            mobileInstructions.SetActive(true);
        }
        else
        {
            pcInstructions.SetActive(true);
        }
    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene("Pong Title Screen");
    }
}

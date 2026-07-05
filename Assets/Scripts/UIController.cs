using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject startMessage;
    [SerializeField] private GameObject loseMessage;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text playAgain;

    public void showStartScene()
    {
        startMessage.SetActive(true);
        loseMessage.SetActive(false);
        scoreText.gameObject.SetActive(false);
        playAgain.gameObject.SetActive(false);
    }

    public void showPlayingScene()
    {
        startMessage.SetActive(false);
        loseMessage.SetActive(false);
        scoreText.gameObject.SetActive(true);
        playAgain.gameObject.SetActive(false);
    }

    public void showGameOverScene()
    {
        loseMessage.SetActive(true);
        playAgain.gameObject.SetActive(true);
    }

    public void updateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}

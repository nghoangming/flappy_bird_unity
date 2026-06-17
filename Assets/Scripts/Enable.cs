using UnityEngine;
using UnityEngine.UI;

public class Enable : MonoBehaviour
{
    public GameObject bird;
    public GameObject message;
    public GameObject text;
    public GameObject loseMessage;
    public GameObject playAgain;


    public void enableBird()
    {
        bird.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void disableBird()
    {
        bird.GetComponent<SpriteRenderer>().enabled = false;
    }


    public void enableMessage()
    {
        message.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void disableMessage()
    {
        message.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void enableText()
    {
        text.GetComponent<Text>().enabled = true;
    }
    public void disableText()
    {
        text.GetComponent<Text>().enabled = false;
    }

    public void enableLoseMessage()
    {
        loseMessage.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void disableLoseMessage()
    {
        loseMessage.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void enablePlayAgain()
    {
        playAgain.GetComponent<Text>().enabled = true;
    }
    public void disablePlayAgain()
    {
        playAgain.GetComponent<Text>().enabled = false;
    }
}

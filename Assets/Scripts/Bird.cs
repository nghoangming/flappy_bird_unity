using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    public float jumpForce;
    private bool startGame;
    private int score;
    public GameObject gameController;
    public Text scoreText;
    public SoundController soundController;
    public Enable enable;
    private bool gameOver;
    
    private void Awake()
    {
        gameOver = false;
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        startGame = false;
        rigidbody.gravityScale = 0;
        scoreText.text = score.ToString();
        score = 0;
        enable.enableMessage();
        enable.disableBird();
        enable.disableText();
        enable.disableLoseMessage();
        enable.disablePlayAgain();
    }

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                reloadScene();
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(startGame == false)
            {
                startGame = true;
                rigidbody.gravityScale = 6;
                gameController.GetComponent<CreatePipe>().enableCreatePipe = true;
                enable.disableMessage(); 
                enable.enableBird();
                enable.enableText();
            }
            BirdMoveUp();
        }
    }
    
    private void BirdMoveUp()
    {
        rigidbody.linearVelocity = Vector2.up * jumpForce;
        soundController.playWingSound();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {  
        gameOver = true;
        soundController.playHitSound();
        soundController.playDieSound();
        enable.enableLoseMessage();
        enable.enablePlayAgain();
        rigidbody.linearVelocity = Vector2.zero;
        rigidbody.gravityScale = 0;
        gameController.GetComponent<CreatePipe>().enableCreatePipe = false;
        Time.timeScale = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
        scoreText.text = score.ToString();
        soundController.playPointSound();
    }

    private void reloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("_gameplay");
    }
}

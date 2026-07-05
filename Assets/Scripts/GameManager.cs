using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
    {
        Waiting,
        Playing,
        GameOver
    }
public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance {get; private set;}
    [SerializeField] private BirdController birdController;
    [SerializeField] private PipeController pipeController;
    [SerializeField] private UIController uiController;

    public GameState gameState {get; private set;}
    public int score {get; private set;}  

    
    void Awake()
    {
        if(Instance == null)    
        {
            Instance = this;
            Time.timeScale = 1;
        } else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        gameState = GameState.Waiting;
        score = 0;
        birdController.prepareBird();
        pipeController.stopPipes();
        uiController.showStartScene();
        uiController.updateScore(score);
    }

    public void HandleJumpInput()
    {
        if (gameState == GameState.GameOver)
        {
            RestartGame();
            return;
        }

        if (gameState == GameState.Waiting)
        {
            startGame();
        }

        if (gameState == GameState.Playing)
        {
            birdController.requestJump();
        }
    }

    public void startGame()
    {
        if (gameState != GameState.Waiting) return;
        gameState = GameState.Playing;
        birdController.startBird();
        pipeController.startPipes();
        uiController.showPlayingScene();
    }

    public void addScore()
    {
        if (gameState != GameState.Playing) return;
        score++;
        uiController.updateScore(score);
        SoundController.Instance.playPointSound();
    }
    /*
    Đổi trạng thái sang GameOver
    Dừng pipe
    Hiện màn hình thua
    Phát hit sound + die sound
    Dừng thời gian game
    */
    public void GameOver()
    {
        if (gameState == GameState.GameOver) return;
        gameState = GameState.GameOver;
        birdController.stopBird();
        pipeController.stopPipes();
        uiController.showGameOverScene();
        SoundController.Instance.playHitSound();
        SoundController.Instance.playDieSound();
        Time.timeScale = 0;
    }
    /*
    Cho thời gian chạy lại
    Load lại scene hiện tại
    */
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("_gameplay");
    }
}

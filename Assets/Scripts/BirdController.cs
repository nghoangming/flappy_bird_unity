using System;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private BirdConfig birdConfig;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool jumpRequested;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void prepareBird()
    {
        jumpRequested = false;
        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.zero;
        spriteRenderer.enabled = false;
    }
    public void startBird()
    {
    
        rb.gravityScale = birdConfig.gravityScale;
        spriteRenderer.enabled = true;
        
    }
    public void requestJump()
    {
        if (GameManager.Instance.gameState != GameState.Playing) return;
        jumpRequested = true;
    }

     private void FixedUpdate()
    {
        if (!jumpRequested) return;
        rb.linearVelocity = Vector2.up * birdConfig.jumpForce;
        SoundController.Instance.playWingSound();
        jumpRequested = false;
    }

    public void stopBird()
    {
        jumpRequested = false;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.addScore();
    }


}

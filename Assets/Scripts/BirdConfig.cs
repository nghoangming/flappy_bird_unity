using UnityEngine;

[CreateAssetMenu(fileName = "BirdConfig", menuName = "FlappyBird/BirdConfig")]
public class BirdConfig : ScriptableObject
{
    public float jumpForce = 12f;
    public int gravityScale = 6;
}

using Unity.VisualScripting;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance {get; private set;}
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip pointSound;
    [SerializeField] private AudioClip swooshSound;
    [SerializeField] private AudioClip wingSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void playDieSound()
    {
        playSound(dieSound);
    }
    public void playPointSound()
    {
        playSound(pointSound);
    }
    public void playHitSound()
    {
        playSound(hitSound);
    }
    public void playSwooshSound()
    {
        playSound(swooshSound);
    }
    public void playWingSound()
    {
        playSound(wingSound);
    }

    public void playSound(AudioClip clip)
    {
        if (clip == null)
        {
            return;   
        }
        audioSource.PlayOneShot(clip);
    }
}

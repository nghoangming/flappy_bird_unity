using Unity.VisualScripting;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource dieSound;
    public AudioSource hitSound;
    public AudioSource pointSound;
    public AudioSource swooshSound;
    public AudioSource wingSound;

    public void playDieSound()
    {
        dieSound.PlayOneShot(dieSound.clip);
    }
    public void playPointSound()
    {
        dieSound.PlayOneShot(pointSound.clip);
    }
    public void playHitSound()
    {
        dieSound.PlayOneShot(hitSound.clip);
    }
    public void playSwooshSound()
    {
        dieSound.PlayOneShot(swooshSound.clip);
    }
    public void playWingSound()
    {
        dieSound.PlayOneShot(wingSound.clip);
    }
}

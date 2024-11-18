using UnityEngine;

public class AudioControl : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip bubbleSound; // Звук пузырька
    public float soundVolume = 0.5f; // Громкость звука

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = bubbleSound;
    }

    public void PlayBubbleSound()
    {
        audioSource.volume = soundVolume;
        audioSource.PlayOneShot(bubbleSound);
    }
}

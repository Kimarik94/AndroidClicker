using UnityEngine;

public class AudioControl : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip bubbleSound; // ���� ��������
    public float soundVolume = 0.5f; // ��������� �����

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

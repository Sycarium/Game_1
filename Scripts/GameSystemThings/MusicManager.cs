using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Add your AudioClip variables for different music tracks
    public AudioClip standardMusic;
    public AudioClip bossMusic;
    public AudioClip victoryMusic;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Start playing standard music on start
        PlayMusic(standardMusic);
    }

    // Play a music track
    void PlayMusic(AudioClip music)
    {
        if (music != null)
        {
            audioSource.clip = music;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Music file is null.");
        }
    }

    // Switch to boss music
    public void BossMusic()
    {
        // Stop the current music
        audioSource.Stop();

        // Play boss music
        PlayMusic(bossMusic);
    }

    // Play victory soundtrack
    public void VictoryMusic()
    {
        // Stop the current music
        audioSource.Stop();

        // Play victory music
        PlayMusic(victoryMusic);
    }
}

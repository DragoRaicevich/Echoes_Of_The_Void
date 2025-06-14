using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource wiringAudioSource;
    [SerializeField] private AudioSource coreAudioSource;
    [SerializeField] private AudioClip[] audioCoreZoneClips;
    [SerializeField] private AudioClip[] audioWiringZoneClips;
    [SerializeField] private AudioClip[] audioGeneralClips;


    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PlayGeneralSound(int clipIndex, float volume)
    {
        if (clipIndex < 0 || clipIndex >= audioGeneralClips.Length)
        {
            Debug.LogWarning("Invalid audio WIRING clip index: " + clipIndex);
            return;
        }
        coreAudioSource.clip = audioGeneralClips[clipIndex];
        coreAudioSource.volume = volume;
        coreAudioSource.Play();
    }
    public void PlayWiringZoneSound(int clipIndex, float volume)
    {
        if (clipIndex < 0 || clipIndex >= audioWiringZoneClips.Length)
        {
            Debug.LogWarning("Invalid audio WIRING clip index: " + clipIndex);
            return;
        }
        wiringAudioSource.clip = audioWiringZoneClips[clipIndex];
        coreAudioSource.volume = volume;
        wiringAudioSource.Play();
    }
    public void PlayCoreZoneSound(int clipIndex, float volume)
    {
        if (clipIndex < 0 || clipIndex >= audioCoreZoneClips.Length)
        {
            Debug.LogWarning("Invalid audio CORE clip index: " + clipIndex);
            return;
        }
        coreAudioSource.clip = audioCoreZoneClips[clipIndex];
        coreAudioSource.volume = volume;
        coreAudioSource.Play();
    }

}

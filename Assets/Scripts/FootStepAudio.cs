using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepAudio : MonoBehaviour
{
    public CharacterController controller;
    public AudioClip[] footstepSounds;
    public float stepInterval = 0.5f;

    private float stepTimer;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        stepTimer = stepInterval;
    }

    void Update()
    {
        if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = stepInterval;
        }
    }

    void PlayFootstep()
    {
        if (footstepSounds.Length == 0) return;
        int index = Random.Range(0, footstepSounds.Length);
        audioSource.clip = footstepSounds[index];
        audioSource.Play();
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class SimpleFootstep : MonoBehaviour
{
    public AudioClip footstepSound;
    public float stepInterval = 0.5f;

    private AudioSource audioSource;
    private float timer;
    private bool isWalking;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer = stepInterval;
    }

    void Update()
    {
        if (isWalking)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                PlayStep();
                timer = stepInterval;
            }
        }
        else
        {
            timer = stepInterval;
        }
    }

    void PlayStep()
    {
        if (footstepSound != null)
            audioSource.PlayOneShot(footstepSound);
    }

    // Estos métodos se conectan al Input System
    public void OnFootstep(InputAction.CallbackContext context)
    {
        if (context.performed)
            isWalking = true;
        else if (context.canceled)
            isWalking = false;
    }
}

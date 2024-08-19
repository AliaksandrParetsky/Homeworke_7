using UnityEngine;

public class AudioMovement : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    private void Start()
    {
        StopAudio();
    }

    public void PlayAudio()
    {
        source.Play();
    }

    public void StopAudio()
    {
        source.Pause();
    }
}

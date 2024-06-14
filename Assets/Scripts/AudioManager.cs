using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _explosionSound;

    private AudioSource _audioSource;

    public void PlayExplosionSound() => _audioSource.Play();

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _explosionSound;
    }
}

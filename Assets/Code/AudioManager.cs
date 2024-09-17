using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _bgmAudio;
    [SerializeField] private GameObject _sfxPrefab;

    private void Start()
    {
        PlayBGM();
    }

    private void PlayBGM()
    {
        _bgmAudio.Play();
    }

    public void PlaySFX(Vector3 spawnPosition)
    {
        Instantiate(_sfxPrefab, spawnPosition, Quaternion.identity);
    }
}
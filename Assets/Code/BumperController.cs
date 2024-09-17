using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class BumperController : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private VFXManager _vfxManager;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private float _multiplier;
    [SerializeField] private Color _color;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        GetComponent<MeshRenderer>().material.color = _color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.transform.GetComponent<Rigidbody>().velocity *= _multiplier;
            _animator.SetTrigger("Hit");

            _audioManager.PlaySFX(collision.transform.position);
            _vfxManager.PlayVFX(collision.transform.position);
            _scoreManager.AddScore(_score);
        }
    }
}
using UnityEngine;

public class TriggerRampController : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private ScoreManager _scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _scoreManager.AddScore(_score);
        }
    }
}
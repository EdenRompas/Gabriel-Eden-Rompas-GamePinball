using TMPro;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Update()
    {
        _scoreText.text = _scoreManager.score.ToString();
    }
}
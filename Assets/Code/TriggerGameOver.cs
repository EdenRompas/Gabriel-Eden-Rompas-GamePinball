using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerGameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            gameOverCanvas.SetActive(true);
        }
    }
}
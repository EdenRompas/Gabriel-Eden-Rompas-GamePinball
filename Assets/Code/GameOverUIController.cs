using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _mainMenuButton;

    private void Start()
    {
        _playAgainButton.onClick.AddListener(PlayAgain);
        _mainMenuButton.onClick.AddListener(MainMenu);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Pinball_Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
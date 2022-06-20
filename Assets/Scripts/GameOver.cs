using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private TMP_Text _secondsSurvived;

    private bool _gameOver;
    private PlayerController _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _player.Died += OnGameOver;
    }

    private void Update()
    {
        if (_gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
                _gameOver = false;
            }
        }
    }

    private void OnGameOver()
    {
        _gameOverScreen.SetActive(true);
        _secondsSurvived.text = Time.time.ToString();
        _gameOver = true;
        _player.Died -= OnGameOver;
    }
}

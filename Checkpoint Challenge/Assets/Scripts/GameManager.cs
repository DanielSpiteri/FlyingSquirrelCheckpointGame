using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Intro,
        InGame,
        Win,
        Lost
    }

    [Header("Challenge Settings")]
    [SerializeField] private float startingTime = 60f;

    [Header("Checkpoints")]
    [SerializeField] private Checkpoint[] checkpoints;

    [Header("References")]
    [SerializeField] private VehicleController player;

    [Header("UI")]
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private GameObject introPanel;

    private int currentCheckpoint;
    private float remainingTime;

    private GameState currentState;

    private void Start()
    {
        remainingTime = startingTime;
        currentCheckpoint = 0;

        endPanel.SetActive(false);

        UpdateCheckpointVisuals();
        UpdateUI();

        ChangeState(GameState.Intro);
    }

    private void Update()
    {
        switch (currentState)
        {
            case GameState.Intro:
                break;

            case GameState.InGame:
                UpdateGame();
                break;

            case GameState.Win:
                break;

            case GameState.Lost:
                break;
        }
    }

    private void UpdateGame()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            ChangeState(GameState.Lost);
        }

        UpdateUI();
    }

    public void ReachCheckpoint(int checkpointIndex)
    {
        if (currentState != GameState.InGame)
            return;

        if (checkpointIndex != currentCheckpoint)
            return;

        currentCheckpoint++;

        Debug.Log("Checkpoint reached: " + currentCheckpoint);

        UpdateUI();

        if (currentCheckpoint >= checkpoints.Length)
        {
            ChangeState(GameState.Win);
            return;
        }

        UpdateCheckpointVisuals();
    }

    private void ChangeState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.Intro:
                EnterIntroState();
                break;

            case GameState.InGame:
                EnterInGameState();
                break;

            case GameState.Win:
                EnterWinState();
                break;

            case GameState.Lost:
                EnterLostState();
                break;
        }
    }

    private void EnterIntroState()
    {
        Debug.Log("State: Intro");

        introPanel.SetActive(true);

        if (player != null)
            player.enabled = false;
    }

    private void EnterInGameState()
    {
        Debug.Log("State: In Game");

        introPanel.SetActive(false);

        if (player != null)
            player.enabled = true;
    }

    private void EnterWinState()
    {
        Debug.Log("State: Win");

        resultText.text = "YOU WIN!";
        endPanel.SetActive(true);

        StopPlayer();
    }

    private void EnterLostState()
    {
        Debug.Log("State: Lost");

        resultText.text = "TIME'S UP!";
        endPanel.SetActive(true);

        StopPlayer();
    }

    private void UpdateCheckpointVisuals()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].SetHighlighted(i == currentCheckpoint);
        }
    }

    private void UpdateUI()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(remainingTime);

        progressText.text =
            "Checkpoints: " + currentCheckpoint +
            " / " + checkpoints.Length;
    }

    private void StopPlayer()
    {
        if (player == null)
            return;

        player.enabled = false;

        Rigidbody playerRb = player.GetComponent<Rigidbody>();

        if (playerRb != null)
        {
            playerRb.linearVelocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    private void OnValidate()
    {
        startingTime = Mathf.Max(1f, startingTime);
    }

    public void StartGame()
    {
        if (currentState == GameState.Intro)
        {
            ChangeState(GameState.InGame);
        }
    }
}
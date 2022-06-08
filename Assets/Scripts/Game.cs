using Helpers;
using UnityEngine;
using UnityEngine.Events;

public class Game : Scenegleton<Game>
{
    private State state = State.NotStarted;

    public static bool IsPlaying => Instance.state == State.Playing;
    public static bool IsGameOver => Instance.state == State.GameOver;


    public UnityEvent<int> onGameOver;


    public static void Play()
    {
        Instance.state = State.Playing;
    }

    public static void GameOver()
    {
        Instance.state = State.GameOver;
        Instance.onGameOver?.Invoke(ScoreCounter.Score);
    }

    private void Update()
    {
        TryPlay();
        TryRestart();
    }

    private void TryPlay()
    {
        if (state != State.NotStarted) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Play();
        }
    }

    private void TryRestart()
    {
        if (!IsGameOver) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            SceneController.RestartGame();
        }
    }


    private enum State
    {
        NotStarted,
        Playing,
        GameOver
    }
}
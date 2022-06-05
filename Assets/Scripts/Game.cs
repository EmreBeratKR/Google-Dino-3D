using System;
using Helpers;
using UnityEngine;

public class Game : Scenegleton<Game>
{
    private State state = State.Playing;

    public static bool IsPlaying => Instance.state == State.Playing;


    public static void Play()
    {
        Instance.state = State.Playing;
    }

    public static void GameOver()
    {
        Instance.state = State.GameOver;
    }

    private void Update()
    {
        if (IsPlaying) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            SceneController.RestartGame();
        }
    }


    private enum State
    {
        Playing,
        GameOver
    }
}
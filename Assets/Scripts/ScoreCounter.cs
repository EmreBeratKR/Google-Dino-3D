using Helpers;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : Scenegleton<ScoreCounter>
{
    private const float ProgressToScore = 5f;
    
    private float score;
    public static int Score => Mathf.RoundToInt(Instance.score);


    public UnityEvent<int> onScoreChanged;
    private void ScoreChanged(int newScore) => onScoreChanged?.Invoke(newScore);


    private void Update()
    {
        if (!Game.IsPlaying) return;
        
        var deltaProgress = GlobalSpeed.Scale * Time.deltaTime;

        score += deltaProgress * ProgressToScore;
        
        ScoreChanged(Score);
    }
}

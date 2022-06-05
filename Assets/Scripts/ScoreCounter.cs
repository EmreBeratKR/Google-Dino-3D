using Helpers;
using UnityEngine;

public class ScoreCounter : Scenegleton<ScoreCounter>
{
    private const float ProgressToScore = 20f;
    
    private float score;
    public float Score => Mathf.RoundToInt(score);
    
        
    private void Update()
    {
        if (!Game.IsPlaying) return;
        
        var deltaProgress = GlobalSpeed.Scale * Time.deltaTime;

        score += deltaProgress * ProgressToScore;

        Debug.Log(Score);
    }
}

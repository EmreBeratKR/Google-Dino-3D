using Helpers;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : Scenegleton<ScoreCounter>
{
    private const float ProgressToScore = 5f;
    private const int Milestone = 500;
    private const int SubMilestone = 100;
    
    private float score;
    private int lastScore;
    public static int Score => Mathf.RoundToInt(Instance.score);


    public UnityEvent<int> onScoreChanged;
    private void ScoreChanged(int newScore) => onScoreChanged?.Invoke(newScore);

    public UnityEvent onMilestoneReached;
    private void MilestoneReached() => onMilestoneReached?.Invoke();
    
    public UnityEvent onSubMilestoneReached;
    private void SubMilestoneReached() => onSubMilestoneReached?.Invoke();


    private void Update()
    {
        if (!Game.IsPlaying) return;
        
        var deltaProgress = GlobalSpeed.Scale * Time.deltaTime;

        score += deltaProgress * ProgressToScore;
        
        ScoreChanged(Score);

        if (lastScore % SubMilestone > Score % SubMilestone)
        {
            SubMilestoneReached();
        }
        
        if (lastScore % Milestone > Score % Milestone)
        {
            MilestoneReached();
        }

        lastScore = Score;
    }
}

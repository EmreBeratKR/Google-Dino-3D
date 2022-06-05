using NumberRenderer;
using UnityEngine;

[RequireComponent(typeof(NumberMesh))]
public class BestScore : MonoBehaviour
{
    private const string BestScoreKey = "BestScore";

    private NumberMesh numberMesh;

    public int Value
    {
        get => PlayerPrefs.GetInt(BestScoreKey, 0);
        private set => PlayerPrefs.SetInt(BestScoreKey, value);
    }

    
    private void Start()
    {
        numberMesh = GetComponent<NumberMesh>();
        
        numberMesh.Set(Value);
    }

    public void CheckForNewBest(int score)
    {
        Value = Mathf.Max(Value, score);
        numberMesh.Set(Value);
    }
}
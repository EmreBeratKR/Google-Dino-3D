using System.Collections;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform gameOverTitle;
    [SerializeField] private Transform gameOverTarget;
    
    [Header("Show Animation")]
    [SerializeField] private float showDuration;
    [SerializeField] private AnimationCurve showCurve;

    private bool isAnimating;
    


    public void Show()
    {
        if (isAnimating) return;
        
        StartCoroutine(Animation());

        IEnumerator Animation()
        {
            isAnimating = true;
            
            var speed = 1f / showDuration;
            var t = 0f;
            var startPosition = gameOverTitle.position;

            while (true)
            {
                t += Time.deltaTime * speed;

                if (t >= 1f)
                {
                    gameOverTitle.position = gameOverTarget.position;
                    break;
                }
                
                gameOverTitle.position = Vector3.LerpUnclamped(startPosition, gameOverTarget.position, showCurve.Evaluate(t));
                
                yield return null;
            }

            isAnimating = false;
        }
    }
}

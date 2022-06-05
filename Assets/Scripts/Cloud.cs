using UnityEngine;

public class Cloud : MonoBehaviour
{
    private CloudGenerator cloudGenerator;
    private float speed;

    
    private Vector3 RandomScale => Vector3.one * Random.Range(0.2f, 0.5f);
    private float RandomSpeed => Random.Range(0.5f, 5f);

    
    private void Update()
    {
        if (!Game.IsPlaying) return;
        
        Move();
    }

    public void SetGenerator(CloudGenerator generator)
    {
        cloudGenerator = generator;
    }

    public void Randomize()
    {
        transform.position = cloudGenerator.RandomPosition;
        transform.localScale = RandomScale;
        speed = RandomSpeed;
    }

    private void Move()
    {
        transform.position += Vector3.left * (Time.deltaTime * speed);

        if (cloudGenerator.HasExited(this))
        {
            Randomize();
        }
    }
}
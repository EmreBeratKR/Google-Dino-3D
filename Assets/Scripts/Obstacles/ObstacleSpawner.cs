using UnityEngine;
using Random = UnityEngine.Random;

namespace Obstacles
{
    [RequireComponent(typeof(ObstacleMover))]
    public class ObstacleSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform dino;
        [SerializeField] private Obstacle[] obstaclePrefabs;

        [Header("Spawn Interval")]
        [SerializeField, Min(0f)] private float minSpawnInterval;
        [SerializeField, Min(0f)] private float maxSpawnInterval;

        private ObstacleMover obstacleMover;

        private float lastSpawn;
        private float timer;


        private void Start()
        {
            obstacleMover = GetComponent<ObstacleMover>();
        }

        private void Update()
        {
            if (!Game.IsPlaying) return;
            
            TrySpawn();
        }

        private bool TrySpawn()
        {
            if (Time.time - lastSpawn < timer) return false;
            
            Spawn();
            SetTimer();

            return true;
        }

        private void Spawn()
        {
            var randomObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            var position = new Vector3(transform.position.x, 0f, dino.position.z);

            var newObstacle = Instantiate(randomObstacle, position, Quaternion.identity, transform);
            newObstacle.SetMover(obstacleMover);

            lastSpawn = Time.time;
        }

        private void SetTimer()
        {
            timer = Random.Range(minSpawnInterval, maxSpawnInterval) / GlobalSpeed.Scale;
        }
    }
}

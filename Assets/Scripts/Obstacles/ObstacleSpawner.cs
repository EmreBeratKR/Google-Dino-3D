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

        [Header("Spawn Distance")]
        [SerializeField, Min(0f)] private float minSpawnDistance;
        [SerializeField, Min(0f)] private float maxSpawnDistance;

        private ObstacleMover obstacleMover;

        private Obstacle lastSpawnedObstacle;
        private float nextDistance;


        private bool CanSpawn
        {
            get
            {
                if (lastSpawnedObstacle is null) return true;

                return transform.position.x - lastSpawnedObstacle.transform.position.x >= nextDistance;
            }
        }
        

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
            if (!CanSpawn) return false;
            
            Spawn();
            SetNextDistance();

            return true;
        }

        private void Spawn()
        {
            var randomObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            var position = new Vector3(transform.position.x, 0f, dino.position.z);

            var newObstacle = Instantiate(randomObstacle, position, Quaternion.identity, transform);
            newObstacle.SetMover(obstacleMover);

            lastSpawnedObstacle = newObstacle;
        }

        private void SetNextDistance()
        {
            nextDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        }
    }
}

using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] private Transform cloudParent;
    [SerializeField] private Transform[] limits;
    [SerializeField] private Transform exit;
    [SerializeField] private Cloud[] cloudPrefabs;
    [SerializeField] private float poolSize;

    private Cloud RandomCloudPrefab => cloudPrefabs[Random.Range(0, cloudPrefabs.Length)];
    private bool IsPoolFull => cloudParent.childCount >= poolSize;
    
    
    public Vector3 RandomPosition
    {
        get
        {
            var randomY = Random.Range(limits[0].position.y, limits[1].position.y);
            var randomZ = Random.Range(limits[0].position.z, limits[1].position.z);
            return new Vector3(limits[0].position.x, randomY, randomZ);
        }
    }
    

    private void Update()
    {
        if (!Game.IsPlaying) return;
        
        if (IsPoolFull) return;
        
        Spawn();
    }

    public bool HasExited(Cloud cloud)
    {
        return cloud.transform.position.x <= exit.position.x;
    }

    private void Spawn()
    {
        var newCloud = Instantiate(RandomCloudPrefab, cloudParent);
        newCloud.SetGenerator(this);
        newCloud.Randomize();
    }
}

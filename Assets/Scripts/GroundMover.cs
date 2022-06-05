using UnityEngine;

public class GroundMover : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private float speed;

    private Material groundMaterialCopy;


    private void Start()
    {
        groundMaterialCopy = new Material(meshRenderer.material);
    }

    private void Update()
    {
        var textureOffset = groundMaterialCopy.mainTextureOffset;

        textureOffset += Vector2.left * (Time.deltaTime * speed * GlobalSpeed.Scale);
        textureOffset.x %= 1f;

        groundMaterialCopy.mainTextureOffset = textureOffset;

        meshRenderer.material = groundMaterialCopy;
    }
}

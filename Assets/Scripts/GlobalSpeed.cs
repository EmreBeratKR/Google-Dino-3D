using Helpers;
using UnityEngine;

public class GlobalSpeed : Scenegleton<GlobalSpeed>
{
    private const float BaseScale = 1.5f;
    private const float DeltaTimeToDeltaScale = 0.01f;

    private float scale = BaseScale;

    public static float Scale => Instance is null ? BaseScale : Instance.scale;


    private void Update()
    {
        if (!Game.IsPlaying) return;
        
        var deltaScale = Time.deltaTime * DeltaTimeToDeltaScale;
        scale += deltaScale;
    }
}

using Helpers;

public class GlobalSpeed : Scenegleton<GlobalSpeed>
{
    private float scale = 1f;

    public static float Scale => Instance is null ? 1f : Instance.scale;

    public static void Change(float amount)
    {
        Instance.scale += amount;
    }
}

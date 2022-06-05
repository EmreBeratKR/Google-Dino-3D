using Helpers;
using UnityEngine.SceneManagement;

public class SceneController : Scenegleton<SceneController>
{
    public static void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

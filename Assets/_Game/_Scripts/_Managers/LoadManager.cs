using UnityEngine.SceneManagement;
public static class LoadManager
{
    public static void ReloadActiveScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}

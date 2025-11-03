using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private string WorldMap;

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadWorldMap()
    {
        SceneManager.LoadScene(WorldMap);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quiting...");
    }
}

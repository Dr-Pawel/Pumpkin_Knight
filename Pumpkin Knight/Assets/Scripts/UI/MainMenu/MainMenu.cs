using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private string WorldMap;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

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

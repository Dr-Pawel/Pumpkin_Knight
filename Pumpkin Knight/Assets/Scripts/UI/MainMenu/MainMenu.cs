using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private string WorldMap;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] Button firstButtonMainMenu;
    [SerializeField] TMP_Dropdown firstButtonOptions;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SelectButtonMainMenu();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadWorldMap()
    {
        SceneManager.LoadScene(WorldMap);
    }

    public void SelectButtonMainMenu()
    {
        //eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(firstButtonMainMenu.gameObject);
    }

    public void SelectButtonOptions()
    {
        //eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(firstButtonOptions.gameObject);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quiting...");
    }
}

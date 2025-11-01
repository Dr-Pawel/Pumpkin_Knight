using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PlayerMovement playermovement;
    [SerializeField] private string MainMenuLevel;
    
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(MainMenuLevel);
    }

    public void Resume()
    {
        if(playermovement.isPaused)
        {
            playermovement.isPaused = false;
            playermovement.pauseMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

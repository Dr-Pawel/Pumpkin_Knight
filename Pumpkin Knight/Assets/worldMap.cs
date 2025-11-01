using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class worldMap : MonoBehaviour
{
    [SerializeField] private string cryptLevel;
    [SerializeField] private string GraveyardLevel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadCryptLevel()
    {
        SceneManager.LoadScene(cryptLevel);
    }
    public void LoadGraveyardLevel()
    {
        SceneManager.LoadScene(GraveyardLevel);
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class worldMap : MonoBehaviour
{
    [SerializeField] private string cryptLevel;
    [SerializeField] private string GraveyardLevel;

    public void LoadCryptLevel()
    {
        SceneManager.LoadScene(cryptLevel);
    }
    public void LoadGraveyardLevel()
    {
        SceneManager.LoadScene(GraveyardLevel);
    }
}

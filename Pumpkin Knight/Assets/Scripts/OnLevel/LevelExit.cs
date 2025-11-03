using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string nextSceneName = "NextLevel";
    public float fadeDuration = 2f;
    private bool isLoading = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isLoading && other.CompareTag("Player"))
        {
            isLoading = true;
            StartCoroutine(FadeAndLoad());
        }
    }

    private IEnumerator FadeAndLoad()
    {
        ScreenFade fade = FindObjectOfType<ScreenFade>();
        if (fade != null)
            yield return fade.FadeOut(fadeDuration);

        SceneManager.LoadScene(nextSceneName);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
public class Startmenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnStartClick()
    {
        SceneManager.LoadScene("spaceshooter");

    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}

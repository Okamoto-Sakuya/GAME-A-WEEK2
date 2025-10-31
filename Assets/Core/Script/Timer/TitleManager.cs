using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}

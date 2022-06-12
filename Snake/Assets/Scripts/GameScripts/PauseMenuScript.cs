using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public bool PauseGame = false;

    private float _timeScale;

    public void Pause()
    {
        _timeScale = Time.timeScale;
        this.gameObject.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void ResumeButton()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = _timeScale;
        PauseGame = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = _timeScale;
    }
}

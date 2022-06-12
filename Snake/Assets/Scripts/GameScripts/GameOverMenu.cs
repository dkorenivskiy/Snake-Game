using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public bool GameOver = false;

    public void GameOverMenuInstantiate()
    {
        this.gameObject.SetActive(true);
        GameOver = true;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}

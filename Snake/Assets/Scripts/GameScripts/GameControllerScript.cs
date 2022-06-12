using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public ScoreScript ScoreText;
    public PlayerControl PlayerControl;
    public GameOverMenu GameOverMenu;
    public PlayerCoordinatsScript CoordinatsScript;
    public PauseMenuScript PauseMenu;

    private int _score;
    private bool _pauseGame;

    private void Start()
    {
        PlayerControl.OnScoreIncrement += ScoreText.ScoreIncrement;
        PlayerControl.OnGameOverMenu += GameOverMenu.GameOverMenuInstantiate;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                CoordinatsScript.CoordinatsInstantiate();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.Pause();
        }

        if (GameOverMenu.GameOver == false)
        {
            PlayerControl.StopSnake = PauseMenu.PauseGame;
        }
    }
}

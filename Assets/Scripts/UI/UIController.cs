using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public float speedRotation = 0;
    public bool accelerating = false;

    private bool isGaming;

    public Text gameIsStopped;
    public Text startStop;
    public Image image;

    public GameController gameController;

    private void OnValidate()
    {
        gameController = GetComponent<GameController>();
        gameController.EventStarGame += GameController_StarGame;
        gameController.EventStopGame += GameController_StopGame;
    }

    private void GameController_StopGame()
    {
        isGaming = false;
    }

    private void GameController_StarGame()
    {
        isGaming = true;
    }

    public float getManage()
    {
        if (accelerating)
        {
            Vector3 accelerate = Input.acceleration;
            return accelerate.x * 10;
        }
        else
        {
            if (Input.touchCount == 1)
            {
                return (Input.touches[0].position.x - (Screen.width/2)) * speedRotation;
            }
            else
                return 0;
        }
    }

    public void onClickRightButton()
    {
        if (accelerating)
        {
            accelerating = false;
            image.color = new Vector4(1, 0, 0, 1);
        }
        else if (!accelerating)
        {
            accelerating = true;
            image.color = new Vector4(0, 1, 0, 1);
        }
    }

    public void onClickLeftButton()
    {
        if (isGaming)
        {
            gameController.StopGame();
            startStop.text = "Start";
        }
        else if (!isGaming)
        {
            gameController.StartGame();
            startStop.text = "Stop";
        }
    }
}

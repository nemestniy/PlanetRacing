using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public StartConfig config;
    public GameObject player;
    public GenerateMeteor generateMeteor;
    public PlayerController playerController;
    public Text gameIsStopped;
    public Text startStop;
    public Image image;
    public Text score;
    public Text record;

    public delegate void MethoodContainer();
    public event MethoodContainer EventStarGame;
    public event MethoodContainer EventStopGame;

    private int counter = 0;
    private float time;
    private float timer;

    private void Start()
    {
        showRecord();
        time = config.time;
        timer = time;
    }

    private void Update()
    {
        score.text = "Score: " + counter;
        if (generateMeteor.getGenerate()) {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                counter++;
                timer = time;
            }
        }
        if (time > 0.5)
            time -= 0.00001f;
    }

    private void Awake()
    {
        player = GameObject.Find("Player");
        generateMeteor = GetComponent<GenerateMeteor>();
        playerController = player.GetComponent<PlayerController>();
    }

    public void StopGame()
    {
        if (generateMeteor.getGenerate())
        {
            playerController.speedMoving = 0;
            playerController.speedRotation = 0;
            var meteors = GameObject.FindGameObjectsWithTag("Meteor");
            foreach (GameObject meteor in meteors)
                Destroy(meteor);
            generateMeteor.SetGenerate(false);
            gameIsStopped.enabled = true;
            changeRecord();
            startStop.text = "Start";
        }
        EventStopGame();
    }

    public void StartGame()
    {
        if (!generateMeteor.getGenerate())
        {
            playerController.speedMoving = config.speedMoving;
            playerController.speedRotation = config.speedRotation;
            player.transform.position = config.startPositionPlayer;
            generateMeteor.SetGenerate(true);
            gameIsStopped.enabled = false;
            showRecord();
            startStop.text = "Stop";
            counter = 0;
        }
        EventStarGame();
    }

    public float getTimer()
    {
        return generateMeteor.time;
    }

    public void changeRecord()
    {
        if (counter > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", counter);
            record.text = "Record: " + counter;
            counter = 0;
        }
    }
    public void showRecord()
    {
        record.text = "Record: " + PlayerPrefs.GetInt("Record");
    }
}

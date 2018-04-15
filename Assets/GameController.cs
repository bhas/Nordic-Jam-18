using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Score = 0;
    public int Negative = 0;
    public int Triggers = 0;
    public int Counter = 0;

    public ParticleSystem Explosion;
    public Text TargetScoreText;

    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameController();

            return _instance;
        }
    }

    //Awake is always called before any Start functions
    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);

        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        GameEnded = false;

        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);
    }

    bool slowedDown = false;
    float timeScale = 1f;
    float timeToScaleDown = 0.09f;
    public Transform player;
    public CameraController controller;
    public AudioSource[] audios;

    private int countDownToTarget = 10;
    public GameObject WinScreen;
    public GameObject IngameUI;
    public GameObject LoseScreen;

    private bool GameEnded = false;

    void Update()
    {
        if (GameEnded) return;

        if (Score >= TargetScore)
        {
            GameEnded = true;
            StopCoroutine(SlowDownTime(true));
            StartCoroutine(SlowDownTime(false));
            WinScreen.SetActive(true);
            IngameUI.SetActive(false);
            return;
        }

        if (Negative > (TotalAmountOfGoodStuff * 0.3f))
        {
            GameEnded = true;
            StopCoroutine(SlowDownTime(true));
            StartCoroutine(SlowDownTime(false));
            LoseScreen.SetActive(true);
            IngameUI.SetActive(false);
            return;
        }

        if (Triggers > 20 && !slowedDown)
        {
            //controller.Target = Explosion.transform;
            controller.Distance = 10;
            controller.Height = 10;
            slowedDown = true;
            StartCoroutine(SlowDownTime(true));
        }

        if (Triggers > 0)
            Triggers--;

        if (shownTargetAnimation) return;

        countDownToTarget--;
        if (countDownToTarget <= 0)
        {
            shownTargetAnimation = true;
            StartCoroutine(ShowTargetScore());
        }
    }

    private IEnumerator SlowDownTime(bool StartUpAgain)
    {
        timeScale = 1f;
        for (int i = 0; i < 10; i++)
        {
            if (timeScale < 0.5f && !Explosion.isPlaying)
            {
                SoundController.Instance.PlaySound(SoundController.Instance.Explosion);
                Explosion.Play();
            }

            //controller.LerpAmount = i / 10f;

            timeScale -= timeToScaleDown;
            Time.timeScale = timeScale;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            foreach (var audio in audios)
                audio.pitch = timeScale;
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(0.1f);

        if (StartUpAgain)
            StartCoroutine(SpeedUpTime());
    }

    private IEnumerator SpeedUpTime()
    {
        for (int i = 10; i > 0; i--)
        {
            timeScale += timeToScaleDown;

            //controller.LerpAmount = i / 10f;

            Time.timeScale = timeScale;
            foreach (var audio in audios)
                audio.pitch = timeScale;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            yield return new WaitForSeconds(0.02f);
        }
        //controller.Target = player;
        controller.Distance = 30;
        controller.Height = 30;
        slowedDown = false;
        Triggers = 0;
    }

    private int TargetScore = 0;
    private int TotalAmountOfGoodStuff = 0;
    public void GoodThing()
    {
        TotalAmountOfGoodStuff++;
        TargetScore = (int)(TotalAmountOfGoodStuff * 0.7f);
    }

    private IEnumerator ShowTargetScore()
    {
        for (int i = 0; i < TargetScore; i+=5)
        {
            yield return new WaitForSeconds(0.0001f);
            TargetScoreText.text = "Breaking point: " + i;
        }
        TargetScoreText.text = "Breaking point: " + TargetScore;
        SoundController.Instance.PlaySound(SoundController.Instance.TargetSound);
    }

    private int breakCount = 0;
    private bool shownTargetAnimation;

    public void Trigger()
    {
        Triggers++;

        breakCount++;
        if (breakCount > 5)
        {
            breakCount = 0;
            SoundController.Instance.PlaySound(SoundController.Instance.WreckingSound);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

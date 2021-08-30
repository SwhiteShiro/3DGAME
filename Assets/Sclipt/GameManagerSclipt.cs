using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerSclipt : MonoBehaviour
{
    public GameObject scoreObj;         
    public GameObject ScoreObj;         
    public GameObject clickBtn;
    public GameObject _unityChan;
    public GameObject timer;
    public GameObject _contenue;
    public GameObject BackToTitle;
    public GameObject CDtext;           

    public static float _min = 1.0f;
    public static float _max = 30.0f;
    public float rmdX = 0;
    public float rmdZ = 0;
    public float countTime = 10;

    public AudioClip SE_CountDown;
    public AudioClip SE_GameStart;

    private float cTime;
    private float CountDownIntervul = 1.0f;
    private int gameCountDown = 3;
    private int resultScore = 0;
    private int loadScore = 0;

    private bool isPlaying = false;
    private bool checkRmd = false;
    private bool isResult = false;
    private bool isScore = false;

    [SerializeField] private Canvas _cameraRender;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera subCamera;

    TriggerSerch _Score;

    AudioSource _AudioCountDown;

    void Start()
    {
        _AudioCountDown = GetComponent<AudioSource>();

        cTime = countTime;
        scoreObj.GetComponent<TriggerSerch>().Start();
        clickBtn.SetActive(true);
        _unityChan.SetActive(false);
        rmdX = Random.Range(_min, _max);
        rmdZ = Random.Range(_min, _max);
        checkRmd = false;
        scoreObj.SetActive(false);
        _contenue.SetActive(false);
        BackToTitle.SetActive(false);

        _cameraRender.worldCamera = subCamera;

        scoreObj.transform.position = new Vector3(10, 1, 20);
        _unityChan.transform.position = new Vector3(0, 0, 0);

        timer.GetComponent<Text>().text = countTime.ToString("F2");

        _Score = ScoreObj.GetComponent<TriggerSerch>();

        CDtext.SetActive(false);
    }


    void Update()
    {
        if (isPlaying && countTime > 0 && !isResult)
        {


            countTime -= Time.deltaTime;
            timer.GetComponent<Text>().text = countTime.ToString("F2");

            if (countTime <= 0)
            {
                isPlaying = false;
                isResult = true;
            }

            checkRmd = scoreObj.GetComponent<TriggerSerch>().checkTrigger();

            if (checkRmd)
            {
                rmdX = Random.Range(_min, _max);
                rmdZ = Random.Range(_min, _max);
                checkRmd = false;
            }
            else
            {
                scoreObj.transform.position = new Vector3(rmdX, 1, rmdZ);
                scoreObj.SetActive(true);
            }
        }

        if (isResult)
        {
            _cameraRender.GetComponent<Canvas>().worldCamera = subCamera;

            if (!isScore)
            {
                loadScore = PlayerPrefs.GetInt("G1SCORE", 0);

                resultScore = _Score.score + loadScore;

                Debug.Log("??????SCORE???@" + resultScore);
                PlayerPrefs.SetInt("G1SCORE", resultScore);
                PlayerPrefs.Save();
                isScore = true;
            }

            scoreObj.SetActive(false);
            _unityChan.SetActive(false);
            subCamera.gameObject.SetActive(true);
            timer.SetActive(false);

            _contenue.SetActive(true);
            BackToTitle.SetActive(true);
        }
    }

    public void ClickStartGame()
    {
        _cameraRender.GetComponent<Canvas>().worldCamera = mainCamera;

        clickBtn.SetActive(false);
        _unityChan.SetActive(true);
        subCamera.gameObject.SetActive(false);
        timer.SetActive(true);
        
        countTime = cTime;

        _unityChan.transform.position = new Vector3(0, 1, 0);

        StartCoroutine("CountDown");

    }

    IEnumerator CountDown()
    {
        CDtext.SetActive(true);
        CDtext.GetComponent<Text>().text = gameCountDown.ToString();
        _AudioCountDown.PlayOneShot(SE_CountDown);
        gameCountDown = 2;

        yield return new WaitForSeconds(CountDownIntervul);

        CDtext.GetComponent<Text>().text = gameCountDown.ToString();
        _AudioCountDown.PlayOneShot(SE_CountDown);
        gameCountDown = 1;

        yield return new WaitForSeconds(CountDownIntervul);

        CDtext.GetComponent<Text>().text = gameCountDown.ToString();
        _AudioCountDown.PlayOneShot(SE_CountDown);

        yield return new WaitForSeconds(CountDownIntervul);

        CDtext.GetComponent<Text>().text = "START!";
        _AudioCountDown.PlayOneShot(SE_GameStart);
        gameCountDown = 3;

        yield return new WaitForSeconds(0.7f);
        CDtext.SetActive(false);

        //?Q?[?????J?n
        isPlaying = true;
        isResult = false;
        isScore = false;
    }

    public void ClickBackTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void ContenueGame()
    {
        isResult = false;
        isPlaying = false;
        isScore = false;
        countTime = cTime;
        Start();
    }
}

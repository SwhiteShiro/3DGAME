using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game2Manager : MonoBehaviour
{
    public GameObject _startBtn;
    public GameObject _backBtn;
    public GameObject _continueBtn;
    public GameObject timer;

    public GameObject _cube;        //銃のオブジェクト
    public GameObject _site;        //照準

    public GameObject _Score;

    private float countTime;
    private float setTime = 30.0f;

    private int loadScore = 0;
    private int resultScore = 0;

    private bool isPlaying = false;
    private bool isResult = false;
    private bool isScore = false;

    CheckHitBullet bulletScore;

    // Start is called before the first frame update
    void Start()
    {
        _cube.GetComponent<Shooting>().enabled = false;

        isPlaying = false;
        isResult = false;

        timer.GetComponent<Text>().text = "TIME " + countTime.ToString();
        countTime = setTime;

        _startBtn.SetActive(true);
        _backBtn.SetActive(false);
        _continueBtn.SetActive(false);

        bulletScore = _Score.GetComponent<CheckHitBullet>();

        _cube.transform.rotation = Quaternion.identity;
        _site.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying && countTime>0)
        {
            countTime -= Time.deltaTime;
            timer.GetComponent<Text>().text = "TIME " + countTime.ToString("F2");
        }

        if (countTime <= 0)
        {
            timer.GetComponent<Text>().text = "TIME 0:00";
            isPlaying = false;
            isResult = true;
        }

        if (isResult)
        {
            _site.SetActive(false);
            if (!isScore)
            {
                loadScore = PlayerPrefs.GetInt("G2SCORE", 0);

                resultScore = loadScore + bulletScore.score;

                Debug.Log("GAME2のSCOREは " + resultScore + "です");
                PlayerPrefs.SetInt("G2SCORE", resultScore);
                PlayerPrefs.Save();
                isScore = true;
            }


            _cube.GetComponent<Shooting>().enabled = false;

            _continueBtn.SetActive(true);
            _backBtn.SetActive(true);
        }
    }

    public void StartGame2()
    {
        _cube.GetComponent<Shooting>().enabled = true;
        isPlaying = true;
        _startBtn.SetActive(false);
        _site.SetActive(true);
    }
    public void ContinueGame2()
    {
        isPlaying = true;
        _continueBtn.SetActive(false);
        countTime = 0.0f;

        _cube.GetComponent<Shooting>().enabled = true;
        Start();
    }
    public void BackToTitle2()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

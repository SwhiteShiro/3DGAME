using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour
{
    [SerializeField] private GameObject ScoreText;
    [SerializeField] private GameObject BtnCounter;

    private int StartScore = 0;
    private int TitleScore = 0;
    private int Game1Score = 0;
    private int Game2Score = 0;
    private int Counter = 0;

    void Start()
    {
        Counter = ClickStart.counter;

        if (Counter < 1)            //ç≈èâÇÃàÍâÒñ⁄Ç»ÇÁ
        {
            TitleScore = 0;
            PlayerPrefs.SetInt("G1SCORE", TitleScore);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("G2SCORE", TitleScore);
            PlayerPrefs.Save();

            ScoreText.GetComponent<Text>().text = "SCORE " + TitleScore.ToString();

        }
        else if (Counter <= 1)     //2âÒñ⁄à»ç~ÇÕ
        {
            Game1Score = PlayerPrefs.GetInt("G1SCORE", 0);
            Game2Score = PlayerPrefs.GetInt("G2SCORE", 0);

            TitleScore = Game1Score + Game2Score;

            ScoreText.GetComponent<Text>().text = "SCORE " + TitleScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Counter = ClickStart.counter;
        Debug.Log("CounterÇÕÅ@" + Counter + "Å@Ç≈Ç∑");

        Game1Score = PlayerPrefs.GetInt("G1SCORE", 0);
        Game2Score = PlayerPrefs.GetInt("G2SCORE", 0);

        TitleScore = Game1Score + Game2Score;

        ScoreText.GetComponent<Text>().text = "SCORE " + TitleScore.ToString();
    }
}

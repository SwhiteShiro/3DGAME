using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSerch : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject _object;

    public int score = 0;
    public int addScore = 100;

    bool isTrigger = false;

    public void Start()
    {
        score = 0;
        scoreText.GetComponent<Text>().text = "Score " + score.ToString();
    }

    public bool checkTrigger()
    {
        if (!isTrigger) //OnTriggerEnter()���Ă΂�Ă��Ȃ��Ȃ�
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("���蔲����");
        isTrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("���蔲���I�����");

        isTrigger = false;
        score += addScore;
        scoreText.GetComponent<Text>().text = "SCORE " + score.ToString();
    }
}

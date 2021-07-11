using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckHitBullet : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Text;

    public float dx = 30;
    public float dy = 15;

    public int score = 0;

    private void Start()
    {
        Text.GetComponent<Text>().text = "SCORE " + score.ToString();
        Wall.transform.position = new Vector3(0.0f, 50.0f, 70.0f);
    }

    private void Update()
    {
        Wall.transform.position = 
            new Vector3(Mathf.Sin(Time.time)*dx,
            (Mathf.Cos(Time.time)*dy)+50,
            Wall.transform.position.z);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("ï«Ç…íeÇ™ìñÇΩÇËÇ‹ÇµÇΩ");

            score += 100;
            Text.GetComponent<Text>().text = "SCORE " + score.ToString();

            //ï«Ç…ìñÇΩÇ¡ÇΩíeä€Çè¡Ç∑
            Destroy(collision.gameObject);

            Wall.transform.position = new Vector3(0.0f, 50.0f, 70.0f);
        }
    }
}

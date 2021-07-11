using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickStart : MonoBehaviour
{
    [SerializeField] public GameObject startButton;
    [SerializeField] public GameObject backButton;
    [SerializeField] private GameObject galleryBtn;
    [SerializeField] private GameObject galyBackBtn;
    [SerializeField] public GameObject Btn1;            //何かしらのミニゲーム1
    [SerializeField] public GameObject Btn2;            //何かしらのミニゲーム2
    [SerializeField] private GameObject _Camera;
    [SerializeField] private GameObject TitleText;
    [SerializeField] private GameObject ScoreText;
    [SerializeField] private GameObject GalleryFrame;
    [SerializeField] public GameObject Image00;
    [SerializeField] public GameObject Image01;
    [SerializeField] public GameObject ImageBack;

    [SerializeField] private List<GameObject> ImageList = new List<GameObject>();

    public AudioClip SE_select;
    public AudioClip SE_ok;
    AudioSource _audio;

    bool isPlay = false;
    bool isGallery = false;
    bool isImage = false;

    public static int counter = 0;

    void Start()
    {
        _audio = GetComponent<AudioSource>();

        //_Camera.transform.position = new Vector3(0, 0, -10);
        GalleryFrame.transform.position = new Vector3(3, 0, 0);

        //ギャラリーで表示する画像の初期設定
        Image00.SetActive(false);
        Image01.SetActive(false);
        Image01.transform.position = new Vector3(160, 140, 0);
        Image00.transform.position = new Vector3(-100, 140, 0);
        ImageBack.SetActive(false);



        Btn1.SetActive(false);
        Btn2.SetActive(false);
        backButton.SetActive(false);
        galleryBtn.SetActive(false);
        galyBackBtn.SetActive(false);
        GalleryFrame.SetActive(false);
        ScoreText.SetActive(false);
        TitleText.SetActive(true);
        isPlay = false;
        isGallery = false;
    }

    void Update()
    {
        if (isPlay)         //タイトル画面でスタートが押されたら
        {
            if (!isGallery) //スタートが押されてギャラリーが押されていないなら
            {

                //_Camera.transform.position = new Vector3(0, 0, -10);

                Btn1.SetActive(true);
                Btn2.SetActive(true);
                backButton.SetActive(true);
                galleryBtn.SetActive(true);
            }
            else            //スタート画面でギャラリーが押されたら
            {
      
                //_Camera.transform.position = new Vector3(0, 0, -30);                
                GalleryFrame.transform.position = new Vector3(70, 0, 300);

                Btn1.SetActive(false);
                Btn2.SetActive(false);
                backButton.SetActive(false);
                galleryBtn.SetActive(false);

                Image00.SetActive(true);
                Image01.SetActive(true);
            }
        }
        else               //スタートが押されていない or バックボタンで戻った
        {

            //_Camera.transform.position = new Vector3(0, 0, -10);

            Btn1.SetActive(false);
            Btn2.SetActive(false);
            backButton.SetActive(false);
            galleryBtn.SetActive(false);
            GalleryFrame.SetActive(false);
        }
        //ESCを押したらゲーム終了関数を呼び終了
        if (Input.GetKey(KeyCode.Escape)) Quit();
    }

    public void clickStart()
    {

        _audio.PlayOneShot(SE_select);
        ScoreText.SetActive(true);
        TitleText.SetActive(false);
        startButton.SetActive(false);
        isPlay = true;
    }

    public void clickBack()
    {
        _audio.PlayOneShot(SE_select);

        startButton.SetActive(true);
        TitleText.SetActive(true);
        ScoreText.SetActive(false);
        backButton.SetActive(false);
        isPlay = false;
    }

    public void startGame1()
    {
        counter++;
        StartCoroutine("LoadSceneGame");
    }

    IEnumerator LoadSceneGame()
    {
        _audio.PlayOneShot(SE_ok);

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("GameScene1");
        isPlay = false;
    }

    public void startGame2()
    {
        counter++;
        StartCoroutine("LoadSceneGame2");
    }

    IEnumerator LoadSceneGame2()
    {
        _audio.PlayOneShot(SE_ok);

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("GameScene2");
        isPlay = false;
    }

    private void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void ClickGallery()
    {
        _audio.PlayOneShot(SE_select);
        isGallery = true;
        galyBackBtn.SetActive(true);
        GalleryFrame.SetActive(true);
    }

    public void GalleryBack()
    {
        _audio.PlayOneShot(SE_select);
        isGallery = false;
        GalleryFrame.SetActive(false);
        galyBackBtn.SetActive(false);
        Image00.SetActive(false);
        Image01.SetActive(false);
    }

    public void ShowImage00()
    {
        _audio.PlayOneShot(SE_select);

        ImageList[0].SetActive(true);

        GalleryFrame.SetActive(false);
        galyBackBtn.SetActive(false);
        ImageBack.SetActive(true);
        /*
        Image00.SetActive(false);
        Image01.SetActive(false);
        */
        Image01.transform.position = new Vector3(700, 140, 0);
        Image00.transform.position = new Vector3(-500, 140, 0);
    }

    public void ShowImage01()
    {
        _audio.PlayOneShot(SE_select);

        ImageList[1].SetActive(true);

        Image00.SetActive(false);
        Image01.SetActive(false);
        GalleryFrame.SetActive(false);
        galyBackBtn.SetActive(false);
        ImageBack.SetActive(true);
        Image01.transform.position = new Vector3(700, 140, 0);
        Image00.transform.position = new Vector3(-500, 140, 0);
    }

    public void ShowImageBack()
    {
        _audio.PlayOneShot(SE_select);
        Image00.SetActive(false);
        Image01.SetActive(false);
        GalleryFrame.SetActive(true);
        galyBackBtn.SetActive(true);
        ImageBack.SetActive(false);

        ImageList[0].SetActive(false);
        ImageList[1].SetActive(false);

        Image01.transform.position = new Vector3(160, 140, 0);
        Image00.transform.position = new Vector3(-100, 140, 0);
    }
}

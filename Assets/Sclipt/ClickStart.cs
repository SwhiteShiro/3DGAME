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
    [SerializeField] public GameObject Btn1;
    [SerializeField] public GameObject Btn2;
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

        GalleryFrame.transform.position = new Vector3(3, 0, 0);
        Image00.SetActive(false);
        Image01.SetActive(false);
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
        if (isPlay)
        {
            if (!isGallery)
            {
                Btn1.SetActive(true);
                Btn2.SetActive(true);
                backButton.SetActive(true);
                galleryBtn.SetActive(true);
            }
            else
            {
                GalleryFrame.transform.position = new Vector3(210,0,0);

                Btn1.SetActive(false);
                Btn2.SetActive(false);
                backButton.SetActive(false);
                galleryBtn.SetActive(false);

                Image00.SetActive(true);
                Image01.SetActive(true);
            }
        }
        else
        {
            Btn1.SetActive(false);
            Btn2.SetActive(false);
            backButton.SetActive(false);
            galleryBtn.SetActive(false);
            GalleryFrame.SetActive(false);
        }
        
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
        Image00.transform.position = new Vector3(-1000, -1000, 0);
        Image01.transform.position = new Vector3(-1000, -1000, 0);
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
        Image00.transform.position = new Vector3(-1000, -1000, 0);
        Image01.transform.position = new Vector3(-1000, -1000, 0);
    }

    public void ShowImageBack()
    {
        _audio.PlayOneShot(SE_select);
        Image00.SetActive(true);
        Image01.SetActive(true);
        GalleryFrame.SetActive(true);
        galyBackBtn.SetActive(true);
        ImageBack.SetActive(false);

        ImageList[0].SetActive(false);
        ImageList[1].SetActive(false);

        Image00.transform.position = new Vector3(-250, 250, 0);
        Image01.transform.position = new Vector3(-250, 250, 0);
    }
}

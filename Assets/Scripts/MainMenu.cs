using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject HomeMenu;
    [SerializeField] private GameObject LevelSelect;
    [SerializeField] private GameObject LevelSelected;
    [SerializeField] private GameObject VideoIntro;


    [SerializeField] private GameObject GoBackToLVLSelect;
    [SerializeField] private GameObject PlayLevel;



    public VideoPlayer videoPlayerZoomIn;
    public VideoPlayer videoPlayerIntro;
    

    

    public void Start() {
        // HomeMenu.SetActive(true);
        // LevelSelect.SetActive(false);
        // LevelSelected.SetActive(false);
        // VideoIntro.SetActive(false);
        videoPlayerZoomIn.loopPointReached += OnVideoFinished;
        videoPlayerIntro.loopPointReached += OnVideoIntroFinished;

    }
    public void Update() {
        if (VideoIntro != null && VideoIntro.activeSelf && Input.GetKeyDown(KeyCode.Return)) {
            GoToNextScene();
        }
    }
    

    public void GoToIntro () {
        VideoIntro.SetActive(true);
        LevelSelected.SetActive(false);
        HomeMenu.SetActive(false);
        LevelSelect.SetActive(false);
    }

    public void GoLevelSelect () {
        Debug.Log("clicked level select");
        LevelSelect.SetActive(true);
        HomeMenu.SetActive(false); 
        LevelSelected.SetActive(false);
        PlayLevel.SetActive(false);
        GoBackToLVLSelect.SetActive(false);
    }

    public void GoBackHome () {
        HomeMenu.SetActive(true); 
        LevelSelect.SetActive(false);
    }

    public void PlaySelection () {
        LevelSelected.SetActive(true);
        LevelSelect.SetActive(false);
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video Finished Playing");
        // Your code to execute after the video finishes playing goes here
        PlayLevel.SetActive(true);
        GoBackToLVLSelect.SetActive(true);
    }

    void OnVideoIntroFinished(VideoPlayer vp)
    {
        Debug.Log("Video Finished Playing");
        // Your code to execute after the video finishes playing goes here
        GoToNextScene();
    }

    private void GoToNextScene() {
        SceneManager.LoadScene("Final Level");
    }

}

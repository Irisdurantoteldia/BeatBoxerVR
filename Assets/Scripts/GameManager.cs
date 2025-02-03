using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ui;
    public GameObject cubeManager;
    public Dropdown musicDropDown;
    public AudioSource gameMusic;
    public AudioClip[] audioClips;

    public Text scoreText;

    void Start()
    {
        ui.SetActive(true);
        cubeManager.SetActive(false);
        
        if (musicDropDown != null)
        {
            musicDropDown.onValueChanged.AddListener(HandleDropdownChange);
        }

        UpdateScoreUI(); 
    }

    public void StartGame()
    {
        ui.SetActive(false);
        cubeManager.SetActive(true);
        BlockController.score = 0; 
        UpdateScoreUI();
        gameMusic.Play();
    }

    void HandleDropdownChange(int index)
    {
        if (audioClips != null && index >= 0 && index < audioClips.Length)
        {
            gameMusic.clip = audioClips[index];
        }
    }

    void Update()
    {
        UpdateScoreUI(); 
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + BlockController.score; 
        }
    }

    public void GameOver()
    {
        gameMusic.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int _score;
    public Player player;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _GameOverText;
    [SerializeField] private GameObject _playButton;

    private void Awake()
    {
        Application.targetFrameRate = 60;  // oyunun 60 framden fazla olmasını istemiyoruz.
        Pause();
    }

    public void Play()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
        _playButton.SetActive(false);
        _GameOverText.enabled=false;
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    private void Pause()
    {
        Time.timeScale = 0f; // oyunu duraklatıyoruz zaman güncellenmezse updateler calışmaz.
        player.enabled = false; // player kullanılmaz hale geliyor
    }

    public void GameOver()
    {
        _GameOverText.enabled = true;
        _playButton.SetActive(true);
        Pause();
    }

    public void IncreaseScore()
    {
        _score++;
        if (_scoreText.text != null)
        {
            _scoreText.text = _score.ToString();
        }
    }

   
}

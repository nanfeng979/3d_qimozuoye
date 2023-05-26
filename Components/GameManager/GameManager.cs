using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EGameStatus {
    Playing,
    Stop
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public EGameStatus GameStatus { get; private set; }

    void Start()
    {
        if(Instance == null) {
            Instance = this;
        }
    }

    void Update()
    {
        switch (GameStatus) {
            case EGameStatus.Playing:
                GameStatusIsPlaying();
                break;
            case EGameStatus.Stop:
                GameStatusIsStop();
                break;
        }
    }

    public void SetGameStatus(EGameStatus status) {
        GameStatus = status;
    }

    public EGameStatus GetGameStatus() {
        return GameStatus;
    }

    private void GameStatusIsPlaying() {
        // SceneManager.LoadScene("Playing");
        Time.timeScale = 1.0f;
    }

    private void GameStatusIsStop() {
        Time.timeScale = 0.0f;
    }
}

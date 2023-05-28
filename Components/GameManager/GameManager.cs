using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentGameStatus { get; private set; }

    public GameObject Player;
    public GameObject GameTimeCountDown;
    public GameObject Pet;

    void Start()
    {
        if(Instance == null) {
            Instance = this;

            currentGameStatus = new PlayingState(this);
            currentGameStatus.EnterState();
        }

        currentGameStatus = new PlayingState(this);
    }

    void Update()
    {
        currentGameStatus.UpdateState();
    }

    public void SetGameStatus(GameState status) {
        currentGameStatus.ExitState();
        currentGameStatus = status;
        currentGameStatus.EnterState();
    }

    public GameState GetGameStatus() {
        return currentGameStatus;
    }

    public bool GameStatusIsPlaying() {
        return currentGameStatus is PlayingState;
    }
}

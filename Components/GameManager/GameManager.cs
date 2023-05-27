using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EGameStatus {
    Playing,
    Stop
}

public abstract class GameState {
    protected GameManager gameManager;

    public GameState(GameManager gameManager) {
        this.gameManager = gameManager;
    }

    public virtual void EnterState() {}
    public virtual void UpdateState() {}
    public virtual void ExitState() {}
}

public class PlayingState : GameState {
    public PlayingState(GameManager gameManager) : base(gameManager) { }

    public override void EnterState() {
        SceneManager.LoadScene("Playing");
        Debug.Log("start");
        Time.timeScale = 1.0f;
    }

    public override void UpdateState()
    {
        Debug.Log("UpdateState");
    }
}

public class StopState : GameState {
    public StopState(GameManager gameManager) : base(gameManager) { }

    public override void EnterState() {
        Time.timeScale = 0.0f;
    }

    public override void UpdateState()
    {
        Debug.Log("stop");
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentGameStatus { get; private set; }

    void Start()
    {
        if(Instance == null) {
            Instance = this;

            DontDestroyOnLoad(this);

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

    private void GameStatusIsStop() {
        
    }
}

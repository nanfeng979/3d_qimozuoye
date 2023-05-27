using UnityEngine;

public class StopState : GameState {
    public StopState(GameManager gameManager) : base(gameManager) { }

    public override void EnterState() {
        Time.timeScale = 0.0f;
    }
}
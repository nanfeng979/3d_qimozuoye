using UnityEngine;
public class PlayingState : GameState {
    public PlayingState(GameManager gameManager) : base(gameManager) { }

    public override void EnterState() {
        Time.timeScale = 1.0f;
    }
}
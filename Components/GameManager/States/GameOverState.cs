using UnityEngine;

public class GameOverState : GameState {
    public GameOverState(GameManager gameManager) : base(gameManager) { }

    public override void EnterState() {
        Time.timeScale = 0.0f;
        Debug.Log("游戏结束");
    }
}

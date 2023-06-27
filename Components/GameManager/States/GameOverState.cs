using UnityEngine;

public class GameOverState : GameState {
    public GameOverState(GameManager gameManager) : base(gameManager) { }

    // 当进入此状态时，游戏结束。
    public override void EnterState() {
        Time.timeScale = 0.0f;
        Debug.Log("游戏结束");
    }
}

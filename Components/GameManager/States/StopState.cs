using UnityEngine;

public class StopState : GameState {
    public StopState(GameManager gameManager) : base(gameManager) { }

    // 当进入此状态时，游戏停止。
    public override void EnterState() {
        Time.timeScale = 0.0f;
    }
}
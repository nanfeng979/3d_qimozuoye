using UnityEngine.SceneManagement;

public class GameStartState : GameState {
    public GameStartState(GameManager gameManager) : base(gameManager) { }

    // 当进入此状态时，游戏开始。
    public override void EnterState() {
        SceneManager.LoadScene("Playing");
        gameManager.SetGameStatus(new PlayingState(gameManager));
    }
}
using UnityEngine.SceneManagement;

public class GameStartState : GameState {
    public GameStartState(GameManager gameManager) : base(gameManager) { }

    public override void EnterState() {
        SceneManager.LoadScene("Playing");
        gameManager.SetGameStatus(new PlayingState(gameManager));
    }
}
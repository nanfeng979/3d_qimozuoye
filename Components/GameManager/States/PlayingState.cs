using UnityEngine;
public class PlayingState : GameState {
    public PlayingState(GameManager gameManager) : base(gameManager) { }

    public override void EnterState() {
        Time.timeScale = 1.0f;
    }

    public override void UpdateState() {
        GameManager.Instance.Player.GetComponent<PlayerAndCamera>().isPlaying();
        GameManager.Instance.Player.GetComponent<PlayerMove>().isPlaying();
        GameManager.Instance.GameTimeCountDown.GetComponent<GameTimeCountDown>().isPlaying();
        GameManager.Instance.Pet.GetComponent<Pet>().isPlaying();

        if(GameManager.Instance.Player.GetComponent<Character>().GetHP() <= 0) {
            GameManager.Instance.SetGameStatus(new GameOverState(GameManager.Instance));
        }
    }
}
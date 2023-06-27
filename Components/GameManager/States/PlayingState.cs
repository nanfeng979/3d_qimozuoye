using UnityEngine;
public class PlayingState : GameState {
    public PlayingState(GameManager gameManager) : base(gameManager) { }

    // 当进入此状态时, 游戏时间正常流逝。
    public override void EnterState() {
        Time.timeScale = 1.0f;
    }

    // 当进入此状态时，游戏进行中。
    public override void UpdateState() {
        GameManager.Instance.Player.GetComponent<PlayerAndCamera>().isPlaying();
        GameManager.Instance.Player.GetComponent<PlayerMove>().isPlaying();
        GameManager.Instance.GameTimeCountDown.GetComponent<GameTimeCountDown>().isPlaying();
        GameManager.Instance.Pet.GetComponent<Pet>().isPlaying();

        // 如果玩家死亡，游戏结束。
        if(GameManager.Instance.Player.GetComponent<Character>().GetHP() <= 0) {
            GameManager.Instance.SetGameStatus(new GameOverState(GameManager.Instance));
        }
    }
}
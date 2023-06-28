using UnityEngine;

public class GameOverState : GameState {
    public GameOverState(GameManager gameManager) : base(gameManager) { }

    private float OverTime = 1.0f;

    // 当进入此状态时，游戏结束。
    public override void EnterState() {
        if(GameManager.Instance.Player.GetComponent<Character>().GetHP() <= 0) {
            Debug.Log("游戏失败");
        } else if(GameManager.Instance.Enemy.GetComponent<Character>().GetHP() <= 0) {
            OverTime = 3.0f;
            Debug.Log("游戏胜利");
        }
    }

    public override void UpdateState()
    {
        OverTime -= Time.deltaTime;
        if(OverTime <= 0) {
            Time.timeScale = 0.0f;
        }
    }
    
}

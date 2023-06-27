// GameState基类，用来管理游戏状态
public abstract class GameState {
    protected GameManager gameManager;

    public GameState(GameManager gameManager) {
        this.gameManager = gameManager;
    }

    public virtual void EnterState() {}
    public virtual void UpdateState() {}
    public virtual void ExitState() {}
}
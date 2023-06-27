using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// 用于表示游戏已经经过了多久。
public class GameTimeCountDown : MonoBehaviour
{
    public float GameOverTime;

    [SerializeField] private TMP_Text GameTimeText;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            // 重置游戏关卡
            ResetGame();
        }
    }

    public void isPlaying() {
        if(GameManager.Instance.GameStatusIsPlaying()) {
            GameOverTime -= Time.deltaTime;

            if(GameOverTime <= 0.0f) {
                GameOver();
                return;
            }

            // 实时更新倒计时
            GameTimeText.text = "距离游戏结束还剩下：" + GameOverTime.ToString("F6") + " 秒";
        }
    }

    // 暂停游戏
    private void GameOver() {
        GameTimeText.text = "游戏结束";

        // 暂停时间
        GameManager.Instance.SetGameStatus(new StopState(GameManager.Instance));
    }

    // 重开游戏。
    private void ResetGame() {
        GameManager.Instance.SetGameStatus(new GameStartState(GameManager.Instance));
    }
}

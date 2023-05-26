using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimeCountDown : MonoBehaviour
{
    public float GameOverTime;

    [SerializeField] private TMP_Text GameTimeText;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            // 重置游戏关卡
            ResetGame();
        }

        if(GameManager.Instance.GetGameStatus() == EGameStatus.Playing) {
            GameOverTime -= Time.deltaTime;

            if(GameOverTime <= 0.0f) {
                GameOver();
                return;
            }

            // 实时更新倒计时
            GameTimeText.text = "距离游戏结束还剩下：" + GameOverTime.ToString("F6") + " 秒";
        }
    }

    private void GameOver() {
        GameTimeText.text = "游戏结束";

        // 暂停时间
        GameManager.Instance.SetGameStatus(EGameStatus.Stop);
    }

    private void ResetGame() {
        SceneManager.LoadScene("Playing");
        GameManager.Instance.SetGameStatus(EGameStatus.Playing);
    }
}

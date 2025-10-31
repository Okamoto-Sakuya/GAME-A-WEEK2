using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI rankText;   // ランク表示用
    public TextMeshProUGUI timeText;   // 生存時間表示用

    void Start()
    {
        // GameDataから値を取得して表示
        rankText.text = $"ランク：{GameData.Instance.rank}";
        timeText.text = $"生存時間：{Mathf.FloorToInt(GameData.Instance.survivedTime)} 秒";
    }

    // タイトルに戻るボタン用
    public void OnReturnToTitle()
    {
        GameData.Instance.ResetData();
        SceneManager.LoadScene("TitleScene");
    }
}

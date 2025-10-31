using UnityEngine;
using TMPro; // TextMeshProを使う場合
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{
    public TextMeshProUGUI rankText; // InspectorでTextMeshProUGUIをアタッチ

    void Start()
    {
        // GameDataからランクを取得して表示
        string rank = GameData.Instance.rank;
        rankText.text = $"ランク：{rank}";
    }

    // タイトルに戻るボタン用
    public void OnReturnToTitle()
    {
        GameData.Instance.ResetData(); // タイマーやランクをリセット
        SceneManager.LoadScene("TitleScene");
    }
}

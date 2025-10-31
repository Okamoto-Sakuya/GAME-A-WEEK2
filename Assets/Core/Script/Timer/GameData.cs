using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public float survivedTime = 0f;  // 生存時間
    public string rank = "D";        // 最終ランク

    void Awake()
    {
        // シングルトンにしてシーンをまたいでも保持
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // リセット関数
    public void ResetData()
    {
        survivedTime = 0f;
        rank = "D";
    }

    // ランク判定
    public void EvaluateRank()
    {
        if (survivedTime >= 600f)
            rank = "S";
        else if (survivedTime >= 300f && survivedTime < 600f)
            rank = (survivedTime >= 420f) ? "A" : "B"; // 5?7分:A, 3?5分:B
        else if (survivedTime >= 60f)
            rank = "C";
        else
            rank = "D";
    }
}

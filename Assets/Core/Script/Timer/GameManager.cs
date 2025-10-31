using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager1 : MonoBehaviour
{
    [Header("落下させるオブジェクト一覧")]
    public List<GameObject> fallObjects = new List<GameObject>();

    [Header("落下位置の範囲 (XZ軸)")]
    public Vector3 spawnAreaMin = new Vector3(-10f, 10f, -10f);
    public Vector3 spawnAreaMax = new Vector3(10f, 10f, 10f);

    [Header("落下の間隔")]
    public float spawnInterval = 1.0f;

    private float elapsedTime = 0f;
    private int unlockedObjects = 1;
    private bool isGameOver = false;

    void Start()
    {
        GameData.Instance.ResetData();
        elapsedTime = 0f;
        isGameOver = false;
        InvokeRepeating(nameof(SpawnFallingObject), 1f, spawnInterval);
    }

    void Update()
    {
        if (isGameOver) return;

        elapsedTime += Time.deltaTime;
        GameData.Instance.survivedTime = elapsedTime;

        // 時間経過で出現オブジェクト数アップ
        if (elapsedTime >= 540f) unlockedObjects = Mathf.Min(5, fallObjects.Count);
        else if (elapsedTime >= 420f) unlockedObjects = Mathf.Min(4, fallObjects.Count);
        else if (elapsedTime >= 300f) unlockedObjects = Mathf.Min(3, fallObjects.Count);
        else if (elapsedTime >= 180f) unlockedObjects = Mathf.Min(2, fallObjects.Count);

        // 2分でクリア
        if (elapsedTime >= 120f)
        {
            ClearGame();
        }
    }

    void SpawnFallingObject()
    {
        if (isGameOver || fallObjects.Count == 0) return;

        // ? ここを修正：常に fallObjects.Count の範囲でランダム選択
        int index = Random.Range(0, fallObjects.Count);
        GameObject prefab = fallObjects[index];

        // ランダムな位置から落下
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float z = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        float y = spawnAreaMax.y + Random.Range(5f, 10f);
        Vector3 spawnPos = new Vector3(x, y, z);

        // 生成
        GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);

        // 経過時間に応じてスピードアップ
        var falling = obj.GetComponent<FallingObject>();
        if (falling != null)
        {
            falling.fallSpeed = Mathf.Lerp(2f, 15f, elapsedTime / 120f);
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        CancelInvoke(nameof(SpawnFallingObject));

        GameData.Instance.EvaluateRank();
        SceneManager.LoadScene("GameOver");
    }

    public void ClearGame()
    {
        if (isGameOver) return;
        isGameOver = true;
        CancelInvoke(nameof(SpawnFallingObject));

        GameData.Instance.EvaluateRank();
        SceneManager.LoadScene("ResultScene");
    }
}

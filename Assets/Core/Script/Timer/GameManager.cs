using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager1 : MonoBehaviour
{
    [Header("����������I�u�W�F�N�g�ꗗ")]
    public List<GameObject> fallObjects = new List<GameObject>();

    [Header("�����ʒu�͈̔� (XZ��)")]
    public Vector3 spawnAreaMin = new Vector3(-10f, 10f, -10f);
    public Vector3 spawnAreaMax = new Vector3(10f, 10f, 10f);

    [Header("�����̊Ԋu")]
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

        // ���Ԍo�߂ŏo���I�u�W�F�N�g���A�b�v
        if (elapsedTime >= 540f) unlockedObjects = Mathf.Min(5, fallObjects.Count);
        else if (elapsedTime >= 420f) unlockedObjects = Mathf.Min(4, fallObjects.Count);
        else if (elapsedTime >= 300f) unlockedObjects = Mathf.Min(3, fallObjects.Count);
        else if (elapsedTime >= 180f) unlockedObjects = Mathf.Min(2, fallObjects.Count);

        // 2���ŃN���A
        if (elapsedTime >= 120f)
        {
            ClearGame();
        }
    }

    void SpawnFallingObject()
    {
        if (isGameOver || fallObjects.Count == 0) return;

        // ? �������C���F��� fallObjects.Count �͈̔͂Ń����_���I��
        int index = Random.Range(0, fallObjects.Count);
        GameObject prefab = fallObjects[index];

        // �����_���Ȉʒu���痎��
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float z = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        float y = spawnAreaMax.y + Random.Range(5f, 10f);
        Vector3 spawnPos = new Vector3(x, y, z);

        // ����
        GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);

        // �o�ߎ��Ԃɉ����ăX�s�[�h�A�b�v
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

using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public float survivedTime = 0f;  // ��������
    public string rank = "D";        // �ŏI�����N

    void Awake()
    {
        // �V���O���g���ɂ��ăV�[�����܂����ł��ێ�
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

    // ���Z�b�g�֐�
    public void ResetData()
    {
        survivedTime = 0f;
        rank = "D";
    }

    // �����N����
    public void EvaluateRank()
    {
        if (survivedTime >= 600f)
            rank = "S";
        else if (survivedTime >= 300f && survivedTime < 600f)
            rank = (survivedTime >= 420f) ? "A" : "B"; // 5?7��:A, 3?5��:B
        else if (survivedTime >= 60f)
            rank = "C";
        else
            rank = "D";
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI rankText;   // �����N�\���p
    public TextMeshProUGUI timeText;   // �������ԕ\���p

    void Start()
    {
        // GameData����l���擾���ĕ\��
        rankText.text = $"�����N�F{GameData.Instance.rank}";
        timeText.text = $"�������ԁF{Mathf.FloorToInt(GameData.Instance.survivedTime)} �b";
    }

    // �^�C�g���ɖ߂�{�^���p
    public void OnReturnToTitle()
    {
        GameData.Instance.ResetData();
        SceneManager.LoadScene("TitleScene");
    }
}

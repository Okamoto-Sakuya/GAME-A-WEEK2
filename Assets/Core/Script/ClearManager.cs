using UnityEngine;
using TMPro; // TextMeshPro���g���ꍇ
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{
    public TextMeshProUGUI rankText; // Inspector��TextMeshProUGUI���A�^�b�`

    void Start()
    {
        // GameData���烉���N���擾���ĕ\��
        string rank = GameData.Instance.rank;
        rankText.text = $"�����N�F{rank}";
    }

    // �^�C�g���ɖ߂�{�^���p
    public void OnReturnToTitle()
    {
        GameData.Instance.ResetData(); // �^�C�}�[�⃉���N�����Z�b�g
        SceneManager.LoadScene("TitleScene");
    }
}

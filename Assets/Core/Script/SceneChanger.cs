using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���Ǘ��ɕK�v

public class SceneChanger : MonoBehaviour
{
    // �V�[�������C���X�y�N�^�[�Őݒ�ł���悤�ɂ���
    public string sceneName;

    // �{�^������Ăяo���֐�
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

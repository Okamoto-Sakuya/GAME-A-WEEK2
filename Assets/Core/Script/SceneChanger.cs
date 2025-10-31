using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理に必要

public class SceneChanger : MonoBehaviour
{
    // シーン名をインスペクターで設定できるようにする
    public string sceneName;

    // ボタンから呼び出す関数
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

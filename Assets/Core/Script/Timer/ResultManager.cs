using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public Text resultText;
    public Text timeText;

    void Start()
    {
        float time = GameData.Instance.survivedTime;
        string rank = GameData.Instance.rank;

        timeText.text = $"¶‘¶ŠÔF{Mathf.FloorToInt(time)} •b";
        resultText.text = $"ƒ‰ƒ“ƒNF{rank}";
    }

    public void OnReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

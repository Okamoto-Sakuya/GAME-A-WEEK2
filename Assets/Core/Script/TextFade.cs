using UnityEngine;
using TMPro;
using System.Collections;

public class TMPTextFadeSimple : MonoBehaviour
{
    public TMP_Text tmpText;           // Inspector�ŃA�T�C��
    public float speed = 2f;      // �����̑���
    public float minAlpha = 0.3f; // �ŏ������x
    public float maxAlpha = 1f;   // �ő哧���x

    private void Update()
    {
        if (tmpText != null)
        {
            // Mathf.PingPong��0�`1�̊Ԃŉ�������l�𐶐�
            float t = Mathf.PingPong(Time.time * speed, 1f);
            // minAlpha�`maxAlpha�͈̔͂ɕϊ�
            float alpha = Mathf.Lerp(minAlpha, maxAlpha, t);

            Color c = tmpText.color;
            c.a = alpha;
            tmpText.color = c;
        }
    }
}

using UnityEngine;

public class FallingObject : MonoBehaviour
{
    internal float fallSpeed;
    private bool hasLanded = false;

    void OnCollisionEnter(Collision collision)
    {
        // ���łɒn�ʂɓ��������ꍇ�͖���
        if (hasLanded) return;

        // �n�ʂɓ��������ꍇ
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasLanded = true;

            // Rigidbody���~�߂�
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }

            // 1�b��ɏ���
            Destroy(gameObject, 1f);

            Debug.Log($"{name} hit the Ground! Will be destroyed in 1s.");
        }
    }
}

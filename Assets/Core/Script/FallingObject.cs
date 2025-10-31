using UnityEngine;

public class FallingObject : MonoBehaviour
{
    internal float fallSpeed;
    private bool hasLanded = false;

    void OnCollisionEnter(Collision collision)
    {
        // Ç∑Ç≈Ç…ínñ Ç…ìñÇΩÇ¡ÇΩèÍçáÇÕñ≥éã
        if (hasLanded) return;

        // ínñ Ç…ìñÇΩÇ¡ÇΩèÍçá
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasLanded = true;

            // RigidbodyÇé~ÇﬂÇÈ
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }

            // 1ïbå„Ç…è¡Ç∑
            Destroy(gameObject, 1f);

            Debug.Log($"{name} hit the Ground! Will be destroyed in 1s.");
        }
    }
}

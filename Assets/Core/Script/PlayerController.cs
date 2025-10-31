using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private GameManager1 gameManager; // 修正ポイント

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager1>(); // シーン内のGameManager1を探す
    }

    void FixedUpdate()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) move += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) move += Vector3.back;
        if (Input.GetKey(KeyCode.A)) move += Vector3.left;
        if (Input.GetKey(KeyCode.D)) move += Vector3.right;

        if (move.magnitude > 0.1f) move.Normalize();

        Vector3 newPos = rb.position + move * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FallingObject"))
        {
            // 落下物に触れたらゲームオーバー
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
            else
            {
                Debug.LogWarning("GameManager1 が見つかりませんでした！");
            }
        }
    }
}

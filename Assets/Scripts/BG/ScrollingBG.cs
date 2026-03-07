using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    private Renderer bgRenderer;

    void Start()
    {
        bgRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Tạo độ lệch dựa trên thời gian
        float offset = Time.time * speed;
        // Áp dụng vào Material để tạo hiệu ứng cuộn
        bgRenderer.material.mainTextureOffset = new Vector2(0, offset);
    }
}
using UnityEngine;
public class seed : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool isDrop = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && isDrop == false)
            Drop();
        if (isDrop) return;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x = Mathf.Clamp(mousePos.x, -2.7f, 2.7f);
        mousePos.y = 3.5f;
        transform.position = mousePos;
    }
    private void Drop()
    {
        isDrop = true;
        _rb.simulated = true;
    }
}
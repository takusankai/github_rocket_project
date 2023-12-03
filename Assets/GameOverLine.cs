using UnityEngine.SceneManagement;
using UnityEngine;
public class line : MonoBehaviour
{
    private float stayTime;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("seed"))
        {
            stayTime += Time.deltaTime;
            if (stayTime > 4.0f)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("seed"))
        {
            stayTime = 0;
        }
    }
}
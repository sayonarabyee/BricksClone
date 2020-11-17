using UnityEngine;

public class BallReturn : MonoBehaviour
{
    private Launcher launcher;
    private void Awake()
    {
        launcher = FindObjectOfType<Launcher>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        launcher.ReturnBall();
        collision.collider.gameObject.SetActive(false);
    }
}

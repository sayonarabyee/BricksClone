using TMPro;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Brick : MonoBehaviour
{
    private int durability = 5;

    private SpriteRenderer spriteRenderer;
    private TextMeshPro text;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        UpdateState();
    }
    void UpdateState()
    {
        text.SetText(durability.ToString());
        spriteRenderer.color = Color.Lerp(Color.white, Color.red, durability / 10f); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        durability--;
        if (durability > 0)
            UpdateState();
        else
            Destroy(gameObject);
    }

    internal void SetHits(int hits)
    {
        durability = hits;
        UpdateState();
    }
}

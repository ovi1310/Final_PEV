using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Sprite fondoNeutro;
    public Sprite fondoUtopico;
    public Sprite fondoDistopico;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fondoNeutro;
    }

    public void MostrarUtopia()
    {
        spriteRenderer.sprite = fondoUtopico;
    }

    public void MostrarDistopia()
    {
        spriteRenderer.sprite = fondoDistopico;
    }
}

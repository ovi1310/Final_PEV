using UnityEngine;

public class Backgroundstate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public BackgroundManager backgroundManager;

void MatarPersonaje()
{
    backgroundManager.MostrarDistopia();
}

void PerdonarPersonaje()
{
    backgroundManager.MostrarUtopia();
}


}

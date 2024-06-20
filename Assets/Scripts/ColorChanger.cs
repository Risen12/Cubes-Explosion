using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void SetRandomColor(Cube cube)
    {
        Renderer renderer = cube.GetRenderer();
        renderer.material.SetColor("_Color", Random.ColorHSV());
    }
}

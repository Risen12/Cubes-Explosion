using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void SetRandomColor(Cube cube)
    {
        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Random.ColorHSV());
    }
}

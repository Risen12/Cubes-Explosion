using UnityEngine;
using UnityEngine.TextCore.Text;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private CubeClickExplosioner _explosioner;

    private static int _generateCubesPercent = 100;

    private void OnEnable()
    {
        _explosioner.CubeClicked += DestroyCube;
    }

    private void OnDisable()
    {
        _explosioner.CubeClicked -= DestroyCube;
    }

    private void DestroyCube(Vector3 position)
    {
        if(transform.position == position)
            GenerateCubes();
    }

    private void GenerateCubes()
    {
        int minCubeCount = 2;
        int maxCubeCount = 7;

        if (VerifySplitCube() == true)
        {
            int cubesCount = Random.Range(minCubeCount, maxCubeCount);

            for (int i = 0; i < cubesCount; i++)
            {
                GenerateCube();
            }
        }

        Destroy(gameObject);
    }

    private void GenerateCube()
    {
        float radius = 15f;
        float force = 30f;

        GameObject cube = Instantiate(gameObject);
        Vector3 scale = cube.transform.localScale / 2;
        cube.transform.localScale = scale;
        SetRandomColor(cube);

        cube.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
    }

    private void SetRandomColor(GameObject cube)
    { 
        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Random.ColorHSV());
    }

    private bool VerifySplitCube()
    {
        int maxChance = 101;
        int borderChance = 50;

        bool chance = Random.Range(_generateCubesPercent, maxChance) >= borderChance;

        _generateCubesPercent /= 2;
        return chance;
    }
}

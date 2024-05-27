using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private CubeClickExplosioner _explosioner;

    private int _minCubeCount = 2;
    private int _maxCubeCount = 7;
    private int _generateCubesPercent = 100;
    private float _radius = 9f;
    private float _force = 25f;

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
        if (VerifySplitCube() == true)
        {
            int cubesCount = Random.Range(_minCubeCount, _maxCubeCount);

            for (int i = 0; i < cubesCount; i++)
            {
                GenerateCube();
            }
        }

        Destroy(gameObject);
    }

    private void GenerateCube()
    {
        GameObject cube = Instantiate(gameObject);
        Vector3 scale = cube.transform.localScale / 2;
        cube.transform.localScale = scale;
        SetRandomColor(cube);
        cube.GetComponent<Rigidbody>().AddExplosionForce(_force, transform.position, _radius);
    }

    private void SetRandomColor(GameObject cube)
    { 
        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Random.ColorHSV());
    }

    private bool VerifySplitCube()
    {
        int minChance = 0;
        int maxChance = 101;

        bool chance = Random.Range(minChance + _generateCubesPercent, maxChance) >= _generateCubesPercent;

        _generateCubesPercent /= 2;

        return chance;
    }
}

using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Cube _prefab;
    [SerializeField] Explosioner _explosioner;
    [SerializeField] ColorChanger _colorChanger;

    public void SpawnObjects(int splitChance, Transform parent)
    {
        int minCubesCount = 2;
        int maxCubesCount = 7;

        int count = Random.Range(minCubesCount, maxCubesCount);

        for (int i = 0; i < count; i++)
            SpawnObject(splitChance, parent);
    }

    private void SpawnObject(int splitChance, Transform parent)
    {
        int divider = 2;
        Cube cube = Instantiate(_prefab, parent);
        Debug.Log(cube.transform.position);
        Vector3 scale = cube.transform.localScale / divider;
        cube.transform.localScale = scale;
        cube.SetSplitChance(splitChance / divider);

        _colorChanger.SetRandomColor(cube);
        _explosioner.Explode(cube);
    }
}

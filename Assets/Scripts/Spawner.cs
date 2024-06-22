using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private Explosioner _explosioner;
    [SerializeField] private ColorChanger _colorChanger;

    public void SpawnObjects(Cube parent)
    {
        int minCubesCount = 2;
        int maxCubesCount = 7;

        int count = Random.Range(minCubesCount, maxCubesCount);

        for (int i = 0; i < count; i++)
            SpawnObject(parent.SplitChance, parent.transform);

        _explosioner.Explode(parent);
    }

    private void SpawnObject(int splitChance, Transform parent)
    {
        int divider = 2;
        Vector3 position = GetPosition(parent.position);

        Cube cube = Instantiate(_prefab, position, parent.rotation);

        Vector3 scale = parent.localScale / divider;
        cube.transform.localScale = scale;
        cube.SetSplitChance(splitChance / divider);

        _colorChanger.SetRandomColor(cube);
    }

    private Vector3 GetPosition(Vector3 startPosition)
    {
        float[] values = new float[] {-0.1f, 0.1f };

        float addToX = values[Random.Range(0, values.Length)];
        float addToZ = values[Random.Range(0, values.Length)];

        return new Vector3(startPosition.x + addToX, startPosition.y, startPosition.z + addToZ);
    }
}

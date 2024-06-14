using UnityEngine;

public class CubeClickExplosioner : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosioner _explosioner;

    private Ray _ray;
    private Camera _camera;
    private float _maxDistance = 30f;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        int primaryMouseButtonIndex = 0;
        RaycastHit hit;
        Cube cube;

        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistance, Color.yellow);

        if (Physics.Raycast(_ray, out hit, _maxDistance))
        {
            if (Input.GetMouseButtonDown(primaryMouseButtonIndex))
            {
                if(hit.collider.TryGetComponent(out cube))
                {
                    if (cube.VerifySplitCube())
                    {
                        int splitChance = cube.SplitChance;

                        _spawner.SpawnObjects(splitChance, cube);
                    }
                    else
                        _explosioner.CreateExplode(cube);

                    Destroy(cube.gameObject);
                }
            }
        }
    }
}

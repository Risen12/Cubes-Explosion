using System.Threading;
using UnityEngine;

public class CubeClickExplosioner : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private Ray _ray;
    private Camera _camera;
    private float _maxDistance = 10f;

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

        if (Physics.Raycast(_ray, out hit, _maxDistance))
        {
            if (Input.GetMouseButtonDown(primaryMouseButtonIndex))
            {
                if(hit.collider.TryGetComponent(out cube))
                {
                    if (cube.VerifySplitCube())
                    {
                        Transform transform = cube.transform;
                        int splitChance = cube.SplitChance;

                        _spawner.SpawnObjects(splitChance, transform);
                    }

                    Destroy(cube.gameObject);
                }
            }
        }
    }
}

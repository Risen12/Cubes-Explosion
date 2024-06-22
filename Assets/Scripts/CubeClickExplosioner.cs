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

        if (Physics.Raycast(_ray, out hit, _maxDistance))
        {
            if (Input.GetMouseButtonDown(primaryMouseButtonIndex))
            {
                if(hit.collider.TryGetComponent(out cube))
                {
                    if (cube.CanSplit())
                    {
                        _spawner.SpawnObjects(cube);
                    }
                    else
                    {
                        _explosioner.CreateExplode(cube);
                    }

                    Destroy(cube.gameObject);
                }
            }
        }
    }
}

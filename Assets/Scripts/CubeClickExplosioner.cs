using System;
using UnityEngine;

public class CubeClickExplosioner : MonoBehaviour
{
    public event Action<Vector3> CubeClicked;

    [SerializeField] private Ray _ray;
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

        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistance, Color.yellow);

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            if (Input.GetMouseButtonDown(primaryMouseButtonIndex))
            {
                CubeClicked?.Invoke(hit.transform.position);
            }
        }
    }
}

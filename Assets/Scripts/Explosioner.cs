using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 35f;
    [SerializeField] private float _explosionForce = 55f;

    public void Explode(Cube cube) => cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);

}

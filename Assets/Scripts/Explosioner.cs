using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 15f;
    [SerializeField] private float _explosionForce = 30f;

    public void Explode(Cube cube) => cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);

}

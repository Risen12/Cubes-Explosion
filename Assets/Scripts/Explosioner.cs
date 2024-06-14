using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioManager _audioManager;

    public void CreateExplode(Cube cube)
    {
        Transform cubeTransform = cube.transform;
        float explosiondMultiplyier = cube.transform.localScale.x;
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _explosionRadius);

        foreach (Collider item in hits)
        {
            if (item.transform.TryGetComponent(out Cube exposionCube))
            {
                if (exposionCube.TryGetComponent(out Rigidbody rigidbody))
                {
                    rigidbody.AddExplosionForce(_explosionForce * explosiondMultiplyier, cube.transform.position, _explosionRadius * explosiondMultiplyier);
                }
            }
        }

        _audioManager.PlayExplosionSound();
        Instantiate(_explosionEffect, cubeTransform.position, Quaternion.identity);
    }

    public void Explode(Cube cube) => cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);

}

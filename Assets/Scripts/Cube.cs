using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _splitChance = 100;

    private Renderer _renderer;
    private Rigidbody _rigidbody;

    public int SplitChance => _splitChance;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public bool CanSplit()
    {
        int minChance = 1;
        int maxChance = 101;

        int number = Random.Range(minChance, maxChance);

        return number <= _splitChance;
    }

    public Renderer GetRenderer() => _renderer;

    public void SetSplitChance(int chance)
    {
        int minChance = 0;
        int maxChance = 100;

        _splitChance = Mathf.Clamp(chance, minChance, maxChance);
    }

    public void Explode(float force, float radius) => _rigidbody.AddExplosionForce(force, transform.position, radius);

    public void ExplodeFromPosition(float force, float radius, Vector3 position) => _rigidbody.AddExplosionForce(force, position, radius);
}

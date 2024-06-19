using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _splitChance = 100;

    public int SplitChance => _splitChance;

    public bool Split()
    {
        int minChance = 1;
        int maxChance = 101;

        int number = Random.Range(minChance, maxChance);

        return number <= _splitChance;
    }

    public void SetSplitChance(int chance)
    {
        int minChance = 0;
        int maxChance = 100;

        _splitChance = Mathf.Clamp(chance, minChance, maxChance);
    }

    public void Explode(float force, float radius)
    { 
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddExplosionForce(force, transform.position, radius);
    }
}

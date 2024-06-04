using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _splitChance = 100;

    public int SplitChance => _splitChance;

    public bool VerifySplitCube()
    {
        int maxChance = 101;
        int borderChance = 52;

        bool chance = Random.Range(_splitChance, maxChance) >= borderChance;

        return chance;
    }

    public void SetSplitChance(int chance)
    {
        int minChance = 0;
        int maxChance = 100;

        _splitChance = Mathf.Clamp(chance, minChance, maxChance);
    }
}

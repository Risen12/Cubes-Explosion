using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _splitChance = 100;

    public int SplitChance => _splitChance;

    public bool VerifySplitCube()
    {
        int minChance = 1;
        int maxChance = 101;

        int number = Random.Range(minChance, maxChance);

        bool chance = number <= _splitChance;

        return chance;
    }

    public void SetSplitChance(int chance)
    {
        int minChance = 0;
        int maxChance = 100;

        _splitChance = Mathf.Clamp(chance, minChance, maxChance);
    }
}

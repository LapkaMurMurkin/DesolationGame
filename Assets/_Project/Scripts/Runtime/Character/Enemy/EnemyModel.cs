using R3;
using UnityEngine;

public class EnemyModel
{
    public ReactiveProperty<int> CurrentHealth;

    public void Initialize()
    {
        CurrentHealth = new ReactiveProperty<int>(30);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

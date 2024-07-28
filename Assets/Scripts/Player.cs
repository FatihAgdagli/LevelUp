using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event EventHandler OnHit;

    public event EventHandler OnLevelUp;

    private int xpPointPerHit = 1;
    private int xpPointToLevelUp = 5;
    private int actualXp = 0;

    private int level = 1;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Hit();
        }
    }

    private void Hit()
    {
        actualXp += xpPointPerHit;

        //Fire OnHit event at LevelUp if has enough xp to levelUp
        if (actualXp >= xpPointToLevelUp)
        {
            LevelUp();
            return;
        }
        
        OnHit?.Invoke(this, EventArgs.Empty);
    }

    private void LevelUp()
    {
        actualXp = 0;

        xpPointToLevelUp += level * 2;

        level++;

        OnLevelUp?.Invoke(this, EventArgs.Empty);
        OnHit?.Invoke(this, EventArgs.Empty);
    }

    public int GetLevel() => level;

    public float GetXpToLevelUpPercentage() => (float)actualXp / xpPointToLevelUp;
}

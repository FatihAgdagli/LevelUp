using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelUpEffect : MonoBehaviour
{
    private ParticleSystem levelUpParticleSystem;
    private Player player;

    private void Awake()
    {
        levelUpParticleSystem = GetComponent<ParticleSystem>();
    
        player = transform.GetComponentInParent<Player>();
        player.OnLevelUp += Player_OnLevelUp;
    }

    private void Player_OnLevelUp(object sender, System.EventArgs e)
    {
        levelUpParticleSystem.Play();
    }
}

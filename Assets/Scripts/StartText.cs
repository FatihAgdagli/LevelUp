using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private void Start()
    {
        player.OnHit += Player_OnHit;
    }

    private void Player_OnHit(object sender, System.EventArgs e)
    {
        player.OnHit -= Player_OnHit;

        gameObject.SetActive(false);
    }
}

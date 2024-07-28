using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelTMP;

    [SerializeField]
    private Image barImage;


    private Player player;

    private void Awake()
    {
        player = transform.GetComponentInParent<Player>();

        player.OnHit += Player_OnHit;
        player.OnLevelUp += Player_OnLevelUp;

        UpdateLevel();
        UpdateXPBar();
    }

    private void Player_OnHit(object sender, System.EventArgs e)
    {
        UpdateXPBar();
    }

    private void Player_OnLevelUp(object sender, System.EventArgs e)
    {
        UpdateLevel();
    }

    private void UpdateXPBar()
    {
        barImage.fillAmount = player.GetXpToLevelUpPercentage();
    }

    private void UpdateLevel()
    {
        levelTMP.text = $"Level: {player.GetLevel()}";
    }
}

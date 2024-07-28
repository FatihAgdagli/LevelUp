using System;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    public event EventHandler OnComboStarted;
    public event EventHandler OnComboFinished;
    public event Action<int> OnAchivedNewMaxCombo;
    public static ComboSystem Instance { get; private set; }

    [SerializeField]
    private Player player;

    private float maxTimeBetween2HitInSeconds = 2f;
    private float comboTimer = 0f;

    private int comboCount = 0;
    private int maxComboCount = 1;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        player.OnHit += Player_OnHit;
    }

    private void Update()
    {
        HandleComboTimer();
    }

    private void Player_OnHit(object sender, EventArgs e)
    {
        comboCount++;
        comboTimer = maxTimeBetween2HitInSeconds;

        if (comboCount > 1)
        {
            OnComboStarted?.Invoke(this, EventArgs.Empty);
        }
    }

    private void HandleComboTimer()
    {
        if (comboCount == 0)
        {
            return;
        }

        comboTimer -= Time.deltaTime;

        if (comboTimer < 0f)
        {
            CompareComboCountWithMaxComboCount();
            comboCount = 0;
            OnComboFinished?.Invoke(this, EventArgs.Empty);
        }
    }

    private void CompareComboCountWithMaxComboCount()
    {
        if (comboCount > maxComboCount)
        {
            maxComboCount = comboCount;
            OnAchivedNewMaxCombo?.Invoke(maxComboCount);
        }
    }

    public int GetCurrentComboCount() => comboCount;
}

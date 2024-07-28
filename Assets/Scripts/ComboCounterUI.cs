using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboCounterUI : MonoBehaviour
{
    [SerializeField]
    private GameObject comboCounterGameObject;

    private TextMeshPro comboCounterTMP;

    [SerializeField]
    private GameObject maxComboCounterGameObject;

    private TextMeshPro maxComboCounterTMP;

    private void Awake()
    {
        comboCounterTMP = comboCounterGameObject.GetComponent<TextMeshPro>();
        comboCounterGameObject.SetActive(false);

        maxComboCounterTMP = maxComboCounterGameObject.GetComponent<TextMeshPro>();
        maxComboCounterGameObject.SetActive(false);
    }

    private void Start()
    {
        ComboSystem.Instance.OnComboStarted += Instance_OnComboStarted;
        ComboSystem.Instance.OnComboFinished += Instance_OnComboFinished;
        ComboSystem.Instance.OnAchivedNewMaxCombo += Instance_OnAchivedNewMaxCombo;
    }

    private void Instance_OnAchivedNewMaxCombo(int maxComboCount)
    {
        maxComboCounterGameObject.SetActive(true);
        maxComboCounterTMP.text = $"New Max Combo Record: {maxComboCount}";

        StartCoroutine(StartMaxComboTimer());
    }

    private void Instance_OnComboStarted(object sender, System.EventArgs e)
    {
        comboCounterGameObject.SetActive(true);
        comboCounterTMP.text = $"Combo x{ComboSystem.Instance.GetCurrentComboCount()}";
    }

    private void Instance_OnComboFinished(object sender, System.EventArgs e)
    {
        comboCounterGameObject.SetActive(false);
    }

    private IEnumerator StartMaxComboTimer()
    {
        yield return new WaitForSeconds(2f);
        maxComboCounterGameObject.SetActive(false);
    }
}

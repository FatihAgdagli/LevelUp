using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin basicMultiChannelPerlin;

    private float shakeTimeInSeconds = .1f;

    private float shakeMagnitudeOnHit = 1f;
    private float shakeMagnitudeOnLevelUp = 2f;

    private Player player;

    private void Start()
    {
        basicMultiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        player = transform.GetComponentInParent<Player>();
        player.OnHit += Player_OnHit;
        player.OnLevelUp += Player_OnLevelUp;
    }

    private void Player_OnLevelUp(object sender, System.EventArgs e)
    {
        StartCoroutine(Shake(shakeMagnitudeOnLevelUp));
    }

    private void Player_OnHit(object sender, System.EventArgs e)
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake(float shakeMagnitude = 1f)
    {
        basicMultiChannelPerlin.m_AmplitudeGain = shakeMagnitude;

        yield return new WaitForSeconds(shakeTimeInSeconds);

        basicMultiChannelPerlin.m_AmplitudeGain = 0f;
    }
}

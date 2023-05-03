using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Rendering.Universal;

public class BlackoutEventHandler : RandomEventHandler
{
    [SerializeField]
    private float turnOffDuration = 0.1f;

    [SerializeField]
    private float turnOnDuration = 1f;

    [SerializeField]
    private float warnDuration;

    [SerializeField]
    private float warnBrightness;

    [SerializeField]
    private Light2D globalLight;

    private Sequence anim;

    private void Start()
    {
        anim = DOTween.Sequence();

        var warnTween = DOTween.To(() => globalLight.intensity, (v) => globalLight.intensity = v, warnBrightness, warnDuration).SetEase(Ease.OutBounce);
        anim.Append(warnTween);

        var turnOffTween = DOTween.To(() => globalLight.intensity, (v) => globalLight.intensity = v, 0f, turnOffDuration).SetEase(Ease.InElastic, 2f, 1f);
        anim.Append(turnOffTween);

        var turnOnTween = DOTween.To(() => 0f, (v) => globalLight.intensity = v, globalLight.intensity, turnOnDuration).SetEase(Ease.InOutSine);
        anim.Append(turnOnTween);
        anim.Pause();
    }

    public override void ExecuteEvent()
    {
        anim.Rewind();
        anim.Play();
    }
}

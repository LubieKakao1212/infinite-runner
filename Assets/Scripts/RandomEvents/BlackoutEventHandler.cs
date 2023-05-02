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
    private Light2D globalLight;

    private Sequence anim;

    private void Start()
    {
        anim = DOTween.Sequence();

        var turnOffTween = DOTween.To((v) => globalLight.intensity = v, globalLight.intensity, 0f, turnOffDuration).SetEase(Ease.InBack, 0.2f);
        anim.Append(turnOffTween);

        var turnOnTween = DOTween.To((v) => globalLight.intensity = v, 0f, globalLight.intensity, turnOnDuration).SetEase(Ease.InOutSine);
        anim.Append(turnOnTween);
        anim.Pause();
    }

    public override void ExecuteEvent()
    {
        anim.Rewind();
        anim.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Modifiers;

[CreateAssetMenu(menuName = "Powers/Dash")]
public class DashPowerUp : ActivePowerUp
{
    [SerializeField]
    private float SpeedMul;

    [SerializeField]
    private float Duration;

    public override void Activate(ActivePowerupHandler handler, Player player, WorldSpeedManager world)
    {
        handler.SetPowerUp(null);
        player.StartCoroutine(DoDash(player));
    }

    private IEnumerator DoDash(Player player)
    {
        var mod = player.SpeedFactor.AddModifier(NumericModifierType.Mul, SpeedMul);

        yield return new WaitForSeconds(Duration);

        player.SpeedFactor.RemoveModifier(NumericModifierType.Mul, mod);
    }
}

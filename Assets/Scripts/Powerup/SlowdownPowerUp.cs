using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Modifiers;

[CreateAssetMenu(menuName = "Powers/Slow")]
public class SlowdownPowerUp : ActivePowerUp
{
    [SerializeField]
    private float SlowPower;

    [SerializeField]
    private float SlowDuration;

    [SerializeField]
    private float HaltDuration;

    [SerializeField]
    private float SpeedDuattion;

    public override void Activate(ActivePowerupHandler handler, Player player, WorldSpeedManager world)
    {
        handler.SetPowerUp(null);
        player.StartCoroutine(DoSlow(world));
    }

    private IEnumerator DoSlow(WorldSpeedManager world)
    {
        var haltMod = world.SpeedUpFactor.AddModifier(NumericModifierType.Mul, 0f);
        var slowMod = world.SpeedUpFactor.AddModifier(NumericModifierType.Add, -SlowPower);

        yield return new WaitForSeconds(SlowDuration);

        world.SpeedUpFactor.RemoveModifier(NumericModifierType.Mul, haltMod);
        world.SpeedUpFactor.RemoveModifier(NumericModifierType.Add, slowMod);

        yield return new WaitForSeconds(HaltDuration);

        var speedMod = world.SpeedUpFactor.AddModifier(NumericModifierType.Add, SlowPower);

        yield return new WaitForSeconds(SpeedDuattion);

        world.SpeedUpFactor.RemoveModifier(NumericModifierType.Add, speedMod);
    }
}

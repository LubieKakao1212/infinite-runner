using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Modifiers
{
    //Not premade but I will add it to my utils
    public class ModifiableFloat : BaseValueModifiable<float, float, NumericModifierType>
    {
        private float value;

        public ModifiableFloat(float value) : base(value)
        {
        }

        public override float GetValue()
        {
            if (!isDirty)
            {
                return value;
            }

            value = BaseValue;

            foreach (var mod in GetModifiers(NumericModifierType.Mul))
            {
                value *= mod.value;
            }

            foreach (var mod in GetModifiers(NumericModifierType.BaseMulAdd))
            {
                value += BaseValue * mod.value;
            }

            foreach (var mod in GetModifiers(NumericModifierType.Add))
            {
                value += mod.value;
            }

            isDirty = false;

            return value;
        }
    }
}

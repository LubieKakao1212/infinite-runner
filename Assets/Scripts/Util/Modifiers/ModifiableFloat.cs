using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Modifiers
{
    //Not premade but I will add it to my utils
    public class ModifiableFloat : BaseValueModifiable<float, float, NumericModifierType>
    {
        //TODO Cache value in specific cases
        /*private float value;*/

        public ModifiableFloat(float value) : base(value)
        {
        }

        public ModifiableFloat(Func<float> value) : base(value)
        {
        }

        public override float GetValue()
        {
            var defaultValue = BaseValue();
            var value = defaultValue;

            foreach (var mod in GetModifiers(NumericModifierType.Mul))
            {
                value *= mod.value();
            }

            foreach (var mod in GetModifiers(NumericModifierType.BaseMulAdd))
            {
                value += defaultValue * mod.value();
            }

            foreach (var mod in GetModifiers(NumericModifierType.Add))
            {
                value += mod.value();
            }

            return value;
        }
    }
}

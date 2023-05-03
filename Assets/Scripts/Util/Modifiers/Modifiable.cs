using System;
using System.Collections;
using System.Collections.Generic;

namespace Utils.Modifiers
{
    //Not premade but I will add it to my utils
    /// <summary>
    /// Helper class for creating modifiable values
    /// </summary>
    /// <typeparam name="V">Returned Value Type</typeparam>
    /// <typeparam name="M">Modifier Value Type</typeparam>
    /// <typeparam name="E">Modifier Category Enum</typeparam>
    public abstract class Modifiable<V, M, E> where E : Enum
    {
        protected bool isDirty = true;

        private Dictionary<E, HashSet<Modifier<M>>> sortedModifiers = new Dictionary<E, HashSet<Modifier<M>>>();

        /// <summary>
        /// Adds a new modifier to category <paramref name="category"/>
        /// </summary>
        /// <param name="category"></param>
        /// <param name="value"></param>
        /// <returns>Modifier instance</returns>
        public Modifier<M> AddModifier(E category, M value)
        {
            var mod = new Modifier<M>(() => value);

            AddModifier(category, mod);

            return mod;
        }

        /// <summary>
        /// Adds a new modifier to category <paramref name="category"/>
        /// </summary>
        /// <param name="category"></param>
        /// <param name="valueGetter"></param>
        /// <returns>Modifier instance</returns>
        public Modifier<M> AddModifier(E category, Func<M> valueGetter)
        {
            var mod = new Modifier<M>(valueGetter);

            AddModifier(category, mod);

            return mod;
        }


        /// <summary>
        /// Adds a premade modifier to category <paramref name="category"/>
        /// </summary>
        /// <param name="category"></param>
        /// <param name="value"></param>
        /// <returns>true if modifier was succesfully added, false if it was already there</returns>
        public bool AddModifier(E category, Modifier<M> modifier)
        {
            var mods = sortedModifiers.GetOrSetToDefault(category, new HashSet<Modifier<M>>());

            isDirty = true;

            return mods.Add(modifier);
        }
        
        /// <summary>
        /// Removes a modifier from category <paramref name="category"/>
        /// </summary>
        /// <param name="category"></param>
        /// <param name="modifier">Modifier Instance returned by <see cref="AddModifier(E, M)"/>></param>
        /// <returns>true when <paramref name="modifier"/> was found in category <paramref name="category"/>, otherwise false</returns>
        public bool RemoveModifier(E category, Modifier<M> modifier)
        {
            var mods = sortedModifiers.GetOrSetToDefault(category, new HashSet<Modifier<M>>());
            
            isDirty = true;

            return mods.Remove(modifier);
        }

        public IReadOnlyCollection<Modifier<M>> GetModifiers(E type)
        {
            return sortedModifiers.GetOrSetToDefault(type, new HashSet<Modifier<M>>());
        }

        public abstract V GetValue();
    }

    /// <inheritdoc cref="Modifiable{V, M, E}"/>
    public abstract class BaseValueModifiable<V, M, E> : Modifiable<V, M, E> where E : Enum
    {
        public Func<V> BaseValue { get; protected set; }

        public BaseValueModifiable(V value)
        {
            BaseValue = () => value;
        }

        public BaseValueModifiable(Func<V> valueGetter)
        {
            BaseValue = valueGetter;
        }
    }

    public class Modifier<T>
    {
        public Func<T> value;

        public Modifier(Func<T> value) 
        { 
            this.value = value;
        }
    }
}
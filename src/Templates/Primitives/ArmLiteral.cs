
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using PSArm.Types;
using System.Collections.Generic;

namespace PSArm.Templates.Primitives
{

    public abstract class ArmLiteral : ArmExpression
    {
        private readonly object _value;

        protected ArmLiteral(object value, ArmType armType)
        {
            _value = value;
            ArmType = armType;
        }

        public ArmType ArmType { get; }

        public object GetValue() => _value;

        public override IArmElement Instantiate(IReadOnlyDictionary<IArmString, ArmElement> parameters)
            => this;
    }

    public abstract class ArmLiteral<T> : ArmLiteral
    {
        protected ArmLiteral(T value, ArmType armType)
            : base(value, armType)
        {
            Value = value;
        }

        public T Value { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (!(obj is ArmLiteral<T> armVal))
            {
                return false;
            }

            return Equals(Value, armVal.Value);
        }

        public override int GetHashCode()
        {
            if (Value == null)
            {
                return 0;
            }

            return Value.GetHashCode();
        }
    }
}

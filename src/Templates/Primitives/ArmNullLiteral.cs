
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using PSArm.Templates.Operations;
using PSArm.Templates.Visitors;
using PSArm.Types;
using System.ComponentModel;

namespace PSArm.Templates.Primitives
{
    [TypeConverter(typeof(ArmElementConverter))]
    public sealed class ArmNullLiteral : ArmFunctionCallExpression
    {
        public static ArmNullLiteral Value { get; } = new ArmNullLiteral();

        private ArmNullLiteral() : base(new ArmStringLiteral("json"), new [] { new ArmStringLiteral("null") })
        {
        }

        protected override TResult Visit<TResult>(IArmVisitor<TResult> visitor) => visitor.VisitNullValue(this);
    }
}

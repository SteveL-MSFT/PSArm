using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using PSArm.Expression;

namespace PSArm.ArmBuilding
{
    public class ArmSku
    {
        public IArmExpression Name { get; set; }

        public ArmSku Instantiate(IReadOnlyDictionary<string, ArmLiteral> parameters)
        {
            return new ArmSku
            {
                Name = Name.Instantiate(parameters),
            };
        }

        public JObject ToJson()
        {
            return new JObject
            {
                ["name"] = Name.ToExpressionString(),
            };
        }
    }

}
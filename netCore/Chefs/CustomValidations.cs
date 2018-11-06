using System;
using System.ComponentModel.DataAnnotations;

namespace Chefs
{
    public class AtLeast18Attribute : ValidationAttribute
    {
        public AtLeast18Attribute(){}
        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if (dt.Year <= (DateTime.Now.Year - 18))
            {
                return true;
            }
            return false;
        }
    }
}
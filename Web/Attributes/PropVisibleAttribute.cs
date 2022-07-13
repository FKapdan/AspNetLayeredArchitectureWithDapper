using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetLayeredArchitectureWithDapper.Web.Attributes
{
    public class PropVisibleAttribute : Attribute
    {
        public bool Visible { get; set; }
        public PropVisibleAttribute(bool Visible)
        {
            this.Visible = Visible;
        }
    }
}

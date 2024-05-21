using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Attributes
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

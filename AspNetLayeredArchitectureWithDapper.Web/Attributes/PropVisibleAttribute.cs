using System.ComponentModel.DataAnnotations;

namespace AspNetLayeredArchitectureWithDapper.Web.Attributes
{
    public class PropVisibleAttribute : ValidationAttribute
    {
        public bool Visible { get; set; }
        public PropVisibleAttribute(bool Visible)
        {
            this.Visible = Visible;
        }
        public override bool IsValid(object value)
        {
            return Visible;
        }
    }
}

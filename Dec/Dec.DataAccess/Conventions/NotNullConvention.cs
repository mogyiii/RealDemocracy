using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Dec.Common.Attributes;

namespace Dec.DataAccess.Conventions
{
    public class NotNullConvention : AttributePropertyConvention<NotNullAttribute>
    {
        protected override void Apply(NotNullAttribute attribute, IPropertyInstance instance)
        {
            instance.Not.Nullable();
        }
    }
}

namespace RealPage.Properties.Domain.Entity.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}


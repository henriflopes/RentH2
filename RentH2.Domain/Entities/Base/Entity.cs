namespace RentH2.Domain.Entities.Base
{
    public class Entity : ValueObject, IEntity
    {
        public Guid? Id { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}

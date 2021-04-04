namespace Core.Entities.Concrete
{
    // class isimleri tekil olur
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

       
    }


}

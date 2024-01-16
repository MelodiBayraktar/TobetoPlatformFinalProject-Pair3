namespace Core.Entities.Abstracts;
    public interface IUserOperationClaim
    {
        //public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? OperationClaimId { get; set; }

    }

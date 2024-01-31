namespace Business.Dtos.Ability.Responses
{
    public class GetListedAbilityResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
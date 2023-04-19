namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.DtosRelatedIdentity
{
    public class RegistrationResponseDto
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}

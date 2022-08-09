namespace EducationalMaterials.API.Services.Interfaces
{
    public interface IAccountService
    {
        Task<UserDisplayDto> CreateAsync(UserCreateDto dto);
        Task<string> LoginUserAsync(UserLoginDto inputDto);
    }
}

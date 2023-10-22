using ASPNETCORE_BlogProject.Dto.DTO_s.Users;
using ASPNETCORE_BlogProject.Entity.Entities;
using ASPNETCORE_BlogProject.Service.Models;
using Microsoft.AspNetCore.Identity;

namespace ASPNETCORE_BlogProject.Service.Services.Abstract
{
    public interface IUserService
    {
        Task<List<UserListDto>> GetAllUsersWithRoleAsync();
        Task<List<AppRole>> GetAllRolesAsync();
        Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(int userId);
        Task<AppUser> GetAppUserByIdAsync(int userId);
        Task<string> GetUserRoleAsync(AppUser user);
        Task<UserProfileDto> GetUserProfileAsync();
        Task<UserListDto> GetUserProfileAsyncWitRoleAsync();
        Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto);
        Task<WeatherInfo> GetWeatherInfo();
    }
}

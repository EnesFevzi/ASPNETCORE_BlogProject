﻿using ASPNETCORE_BlogProject.Data.UnıtOfWorks;
using ASPNETCORE_BlogProject.Dto.DTO_s.Users;
using ASPNETCORE_BlogProject.Entity.Entities;
using ASPNETCORE_BlogProject.Entity.Enums;
using ASPNETCORE_BlogProject.Service.Extensions;
using ASPNETCORE_BlogProject.Service.Helpers.Images;
using ASPNETCORE_BlogProject.Service.Models;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Xml.Linq;

namespace ASPNETCORE_BlogProject.Service.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnıtOfWork _unitOfWork;
        private readonly IImageHelper _imageHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ClaimsPrincipal _user;

        public UserService(IUnıtOfWork unitOfWork, IImageHelper imageHelper, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
        {
            var map = _mapper.Map<AppUser>(userAddDto);
            map.UserName = userAddDto.Email;
            var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
            if (result.Succeeded)
            {
                var findRole = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                await _userManager.AddToRoleAsync(map, findRole.ToString());
                return result;
            }
            else
                return result;
        }

        public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(int userId)
        {
            var user = await GetAppUserByIdAsync(userId);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return (result, user.Email);
            else
                return (result, null);
        }

        public async Task<List<AppRole>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task<List<UserListDto>> GetAllUsersWithRoleAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var map = _mapper.Map<List<UserListDto>>(users);


            foreach (var item in map)
            {
                var findUser = await _userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await _userManager.GetRolesAsync(findUser));

                item.Role = role;
            }

            return map;
        }

        public async Task<AppUser> GetAppUserByIdAsync(int userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<UserProfileDto> GetUserProfileAsync()
        {
            var userID = _user.GetLoggedInUserId();
            var getImage = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userID, x => x.Image);
            var map = _mapper.Map<UserProfileDto>(getImage);
            map.Image.FileName = getImage.Image.FileName;
            return map;
        }
        public async Task<UserListDto> GetUserProfileAsyncWitRoleAsync()
        {
            var userID = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userID);
            var getImage = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userID, x => x.Image);
            var role = string.Join("", await GetUserRoleAsync(user));
            var map = _mapper.Map<UserListDto>(getImage);
            map.Image.FileName = getImage.Image.FileName;
            map.Role = role;
            return map;
        }

        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return string.Join("", await _userManager.GetRolesAsync(user));
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = await GetAppUserByIdAsync(userUpdateDto.Id);
            var userRole = await GetUserRoleAsync(user);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await _userManager.RemoveFromRoleAsync(user, userRole);
                var findRole = await _roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                await _userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
                return result;
        }
        private async Task<Guid> UploadImageForUser(UserProfileDto userProfileDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            var imageUpload = await _imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
            Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, userEmail);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);

            return image.ImageID;
        }

        public async Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto)
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId);

            if (userProfileDto.CurrentPassword != null)
            {
                var isVerified = await _userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
                if (isVerified && userProfileDto.NewPassword != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
                    if (result.Succeeded)
                    {
                        await _userManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);

                        _mapper.Map(userProfileDto, user);

                        if (userProfileDto.Photo != null)
                            user.ImageID = await UploadImageForUser(userProfileDto);

                        await _userManager.UpdateAsync(user);
                        await _unitOfWork.SaveAsync();

                        return true;
                    }
                    else
                        return false;
                }
                else if (isVerified)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    _mapper.Map(userProfileDto, user);

                    if (userProfileDto.Photo != null)
                        user.ImageID = await UploadImageForUser(userProfileDto);

                    await _userManager.UpdateAsync(user);
                    await _unitOfWork.SaveAsync();
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }


        }

        public async Task<WeatherInfo> GetWeatherInfo()
        {
            string api = "64d476e683236d625b8f0a39392c240a";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            var temperature = double.Parse(document.Descendants("temperature").ElementAt(0).Attribute("value").Value);

            string condition = string.Empty;

            if (temperature >= 30)
            {
                condition = "Bugün hava çok sıcak!";
            }
            else if (temperature >= 20)
            {
                condition = "Bugün hava ılıman.";
            }
            else if (temperature >= 10)
            {
                condition = "Bugün hava serin.";
            }
            else
            {
                condition = "Bugün hava soğuk.";
            }

            return new WeatherInfo
            {
                Condition = condition,
                Temperature = temperature
            };
        }


    }
}


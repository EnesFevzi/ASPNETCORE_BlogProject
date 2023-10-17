using ASPNETCORE_BlogProject.Dto.DTO_s.Articles;
using ASPNETCORE_BlogProject.Dto.DTO_s.Categories;
using ASPNETCORE_BlogProject.Entity.Entities;
using ASPNETCORE_BlogProject.Service.Extensions;
using ASPNETCORE_BlogProject.Service.Services.Abstract;
using ASPNETCORE_BlogProject.Service.Services.Concrete;
using ASPNETCORE_BlogProject.Web.ResultMessages;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCORE_BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;
        private readonly IValidator<Category> _validator;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService,IMapper mapper, IToastNotification toastNotification,IValidator<Category> validator)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }
        public async Task<IActionResult> DeletedCategory()
        {
            var categories = await _categoryService.GetAllCategoriesDeleted();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            var map = _mapper.Map<Category>(categoryAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _categoryService.CreateCategoryAsync(categoryAddDto);
                _toastNotification.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDto categoryAddDto)
        {
            var map = _mapper.Map<Category>(categoryAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _categoryService.CreateCategoryAsync(categoryAddDto);
                _toastNotification.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });

                return Json(Messages.Category.Add(categoryAddDto.Name));
            }
            else
            {
                _toastNotification.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "İşlem Başarısız" });
                return Json(result.Errors.First().ErrorMessage);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Update(int categoryID)
        {
            var article = await _categoryService.GetCategoryByID(categoryID);
            var articleUpdateDto = _mapper.Map<CategoryUpdateDto>(article);
            return View(articleUpdateDto);
        }
        [HttpPost]

        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var map = _mapper.Map<Category>(categoryUpdateDto);
            var result = await _validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

            }
            else
            {
                var name = await _categoryService.UpdateCategoryAsync(categoryUpdateDto);
                _toastNotification.AddSuccessToastMessage(Messages.Category.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> Delete(int categoryID)
        {
            var title = await _categoryService.SafeDeleteCategoryAsync(categoryID);
            _toastNotification.AddSuccessToastMessage(Messages.Category.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(int categoryID)
        {
            var title = await _categoryService.UndoDeleteCategoryAsync(categoryID);
            _toastNotification.AddSuccessToastMessage(Messages.Category.UndoDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
    }
}

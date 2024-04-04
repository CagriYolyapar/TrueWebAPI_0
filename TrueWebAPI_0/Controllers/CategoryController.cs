using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrueWebAPI_0.DesignPatterns.SingletonPattern;
using TrueWebAPI_0.Models;
using TrueWebAPI_0.RequestModels;
using TrueWebAPI_0.ResponseModels;

namespace TrueWebAPI_0.Controllers
{
    public class CategoryController : ApiController
    {
        NorthwindEntities _db;
        public CategoryController()
        {
            _db = DBTool.DbInstance;
        }

        List<CategoryResponseModel> ListCategories()
        {
            return _db.Categories.Select(x => new CategoryResponseModel
            {
                ID = x.CategoryID,
                Name = x.CategoryName,
                Description = x.Description
            }).ToList();
        }


        [HttpGet]
        public List<CategoryResponseModel> GetCategories()
        {
            return ListCategories();
        }

        [HttpGet]
        public CategoryResponseModel GetCategory(int id)
        {
            return _db.Categories.Where(x => x.CategoryID == id).Select(x => new CategoryResponseModel
            {
                ID = x.CategoryID,
                Name = x.CategoryName,
                Description = x.Description
            }).FirstOrDefault();
        }

        [HttpPost]
        public List<CategoryResponseModel> AddCategory(CreateCategoryRequestModel item)
        {
            Category c = new Category()
            {
                CategoryName = item.Name,
                Description = item.Description
            };

            _db.Categories.Add(c);
            _db.SaveChanges();
            return ListCategories();
        }

        [HttpPut]
        public List<CategoryResponseModel> UpdateCategory(UpdateCategoryRequestModel item)
        {
            Category original = _db.Categories.Find(item.ID);
            original.CategoryName = item.Name;
            original.Description = item.Description;
            _db.SaveChanges();
            return ListCategories();
        }

        [HttpDelete]
        public List<CategoryResponseModel> DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return ListCategories();
        }

        [HttpGet]
        
        public List<CategoryResponseModel> SearchCategory(string item)
        {
            return _db.Categories.Where(x => x.CategoryName.Contains(item)).Select(x => new CategoryResponseModel
            {
                ID = x.CategoryID,
                Name = x.CategoryName,
                Description = x.Description
            }).ToList();
        }
    }
}

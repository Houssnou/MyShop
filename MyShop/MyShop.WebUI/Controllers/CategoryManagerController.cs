using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class CategoryManagerController : Controller
    {
        CategoryRepository context;

        public CategoryManagerController()
        {
            context = new CategoryRepository();
        }

        // GET: CategoryManager
        public ActionResult Index()
        {
            List<Category> categories = context.ListCategories().ToList();

            return View(categories);
        }

        public ActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            else
            {
                context.Insert(category);
                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(string Id)
        {
            Category categoryToUpdate = context.Find(Id);
            if (categoryToUpdate == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoryToUpdate);
            }
        }
        [HttpPost]
        public ActionResult Edit(Category category, string Id)
        {
            Category categoryToUpdate = context.Find(Id);

            if (categoryToUpdate == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }

                categoryToUpdate.Name = category.Name;
                
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Category categoryToDelete = context.Find(Id);
            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Category categoryToDelete = context.Find(Id);
            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}
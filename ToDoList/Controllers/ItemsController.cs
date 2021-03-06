using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Models;
using System;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/items")]
    public ActionResult Index()
    {
      List<Item> allItems = Item.GetAll();
      return View(allItems);
    }

    [HttpGet("/items/new")]
    public ActionResult New(int categoryId)
    {
      Category foundCategory = Category.Find(categoryId);
       return View(foundCategory);
    }

    [HttpPost("/items")]
    public ActionResult Create(string description)
    {
      Item newItem = new Item(description);
      newItem.Save();
      List<Item> allItems = Item.GetAll();
      return View("Index", allItems);
    }

    [HttpGet("/items/{itemId}")]
    public ActionResult Show(int categoryId, int itemId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Item selectedItem = Item.Find(itemId);
      List<Category> itemCategories = selectedItem.GetCategories();
      List<Category> allCategories = Category.GetAll();
      model.Add("selectedItem", selectedItem);
      model.Add("itemCategories", itemCategories);
      model.Add("allCategories", allCategories);
      return View(model);
    }

    [HttpPost("/items/{itemId}/categories/new")]
    public ActionResult AddCategory(int itemId, int categoryId)
    {
      Item item = Item.Find(categoryId);
      Category category = Category.Find(categoryId);
      item.AddCategory(category);
      return RedirectToAction("Show", new { id = itemId });
    }
    //
    // [HttpPost("/items/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Item.ClearAll();
    //   return View();
    // }
    //
    // [HttpGet("/categories/{categoryId}/items/{itemId}/edit")]
    // public ActionResult Edit(int categoryId, int itemId)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category category = Category.Find(categoryId);
    //   model.Add("category", category);
    //   Item item = Item.Find(itemId);
    //   model.Add("item", item);
    //   return View(model);
    // }
    //
    // [HttpPost("/categories/{categoryId}/items/{itemId}")]
    // public ActionResult Update(int categoryId, int itemId, string newDescription)
    // {
    //   Item item = Item.Find(itemId);
    //   item.Edit(newDescription);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category category = Category.Find(categoryId);
    //   model.Add("category", category);
    //   model.Add("item", item);
    //   return View("Show", model);
    // }

  }
}

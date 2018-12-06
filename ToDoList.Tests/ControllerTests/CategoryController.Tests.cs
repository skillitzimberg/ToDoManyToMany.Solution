using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Controllers;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryControllerTest
  {
    [TestMethod]
    public void Index_HasCorrectModelType_WordCounterList()
    {
      //Arrange
      ViewResult indexView = new CategoriesController().Index() as ViewResult;

      //Act
      var result = indexView.ViewData.Model;

      //Assert
      Assert.IsInstanceOfType(result, typeof(List<Category>));
    }
  }
}

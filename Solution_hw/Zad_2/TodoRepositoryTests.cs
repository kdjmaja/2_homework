using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad_1;

namespace Zad_2
{
    [TestClass]
    public class TodoRepositoryTests
    {
        private ITodoRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new TodoRepository();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullToDatabaseThrowsException()
        {
            _repository.Add(null);
        }
        [TestMethod]
        public void AddingItemWillAddToDatabase()
        {
            var todoItem = new TodoItem("Groceries");
            _repository.Add(todoItem);
            Assert.AreEqual(1, _repository.GetAll().Count);
            Assert.IsTrue(_repository.Get(todoItem.Id) != null);
        }
        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddingExistingItemWillThrowException()
        {
            var todoItem = new TodoItem("Groceries");
            _repository.Add(todoItem);
            _repository.Add(todoItem);
        }

        [TestMethod]
        public void GettingItemFromDatabase()
        {
            var todoItem = new TodoItem("Meeting");
            _repository.Add(todoItem);

            Assert.AreEqual(todoItem, _repository.Get(todoItem.Id));
        }

        [TestMethod]
        public void GettingItemFromEmptyDatabase()
        {
            var item = new TodoItem("Homework");

            Assert.AreNotEqual(item, _repository.Get(item.Id));
            Assert.IsNull(_repository.Get(item.Id));
        }

        [TestMethod]
        public void RemovingFromDatabase()
        {
            var item = new TodoItem("Homework");

            _repository.Add(item);
            Assert.AreEqual(1, _repository.GetAll().Count);
            _repository.Remove(item.Id);
            Assert.AreEqual(0, _repository.GetAll().Count);
            Assert.AreNotEqual(item, _repository.Get(item.Id));
            Assert.IsNull(_repository.Get(item.Id));
        }

        [TestMethod]
        public void RemovingFromEmptyDatabase()
        {
            Assert.IsFalse(_repository.Remove(Guid.NewGuid()));
            Assert.AreEqual(0, _repository.GetAll().Count);
        }

        [TestMethod]
        public void GettingActiveItemsFromDatabase()
        {
            var item1 = new TodoItem("Studying");
            var item2 = new TodoItem("Lunch");

            item2.MarkAsCompleted();
            _repository.Add(item1);
            _repository.Add(item2);

            Assert.AreEqual(1, _repository.GetActive().Count);
            _repository.Remove(item1.Id);
            item1.MarkAsCompleted();
            _repository.Add(item1);
            Assert.AreEqual(0, _repository.GetActive().Count);
        }

        [TestMethod]
        public void GettingAllItems()
        {
            var item1 = new TodoItem("Sleeping");
            var item2 = new TodoItem("Birthday");
            var item3 = new TodoItem("Movie");

            _repository.Add(item1);
            _repository.Add(item2);
            _repository.Add(item3);

            Assert.AreEqual(3, _repository.GetAll().Count);
        }

        [TestMethod]
        public void GettingCompletedItems()
        {
            var item1 = new TodoItem("Dog");
            var item2 = new TodoItem("Dinner");

            item1.MarkAsCompleted();

            _repository.Add(item1);
            _repository.Add(item2);

            Assert.AreEqual(1, _repository.GetCompleted().Count);
        }

        [TestMethod]
        public void GettingFilteredItems()
        {
            var item1 = new TodoItem("Coffee");
            var item2 = new TodoItem("Pancakes");
            var item3 = new TodoItem("Marathon");

            _repository.Add(item1);
            _repository.Add(item2);
            _repository.Add(item3);

            Assert.AreEqual(3, _repository.GetAll().Count);

            Assert.AreEqual(2, _repository.GetFiltered(m => m.Text.Length > 6).Count);
            Assert.AreEqual(1, _repository.GetFiltered(m => m.Text.Length <= 6).Count);
            Assert.AreEqual("Coffee", _repository.GetFiltered(m => m.Text.Length <= 6).First().Text);

        }

        [TestMethod]
        public void MarkingAsCompleted()
        {
            var item1 = new TodoItem("Camping");
            var item2 = new TodoItem("BBQ");

            item1.MarkAsCompleted();

            Assert.IsTrue(item1.IsCompleted);
            Assert.IsFalse(item2.IsCompleted);

        }
        [TestMethod]
        public void UpdateItemInDatabase()
        {
            var item = new TodoItem("Cleaning");

            _repository.Add(item);
            Assert.AreEqual(1, _repository.GetAll().Count);

            item.MarkAsCompleted();
            _repository.Update(item);
            Assert.AreEqual(1, _repository.GetAll().Count);
            Assert.AreEqual(item, _repository.GetAll().First());

            _repository.Update(new TodoItem("Cinema"));
            Assert.AreEqual(2, _repository.GetAll().Count);
        }
    }
}


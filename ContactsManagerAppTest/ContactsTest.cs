using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactsManagerApp.Controllers;
using ContactsManagerApp.Client;
using ContactsManagerApp.Models;
using System.Collections.Generic;

//Truncate the DB Table and then run the tests else change the id appropriately from 1 to whatever

namespace ContactsManagerAppTest
{
    [TestClass]
    public class ContactsTest
    {
        [TestMethod]
        public void TestCreateView()
        {
            var controller = new ContactsController();
            var result = controller.Create() as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void TestCreateRedirect()
        {
            var controller = new ContactsController();

            //List<Contact> contactsList = null;
            Contact contact = new Contact
            {
                FirstName = "Farhat",
                LastName = "Peerzada",
                Email = "abc@xyz.org",
                PhoneNumber = "9988776655",
                Status = (int)ContactStatus.Active
            };
            //contactsList.Add(contact);


            var result = (RedirectToRouteResult)controller.Create(contact);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void TestIndexView()
        {
            var controller = new ContactsController();
            var result = controller.Index() as ViewResult;
            var contactList = (IEnumerable<Contact>)result.ViewData.Model;            
            foreach(var item in contactList)
                Assert.AreEqual("Farhat", item.FirstName);
        }

        [TestMethod]
        public void TestEditView()
        {
            var controller = new ContactsController();
            var result = controller.Edit(1) as ViewResult;
            var contact = (Contact)result.ViewData.Model;
            Assert.AreEqual("Farhat", contact.FirstName);
        }

        [TestMethod]
        public void TestEditRedirect()
        {
            var controller = new ContactsController();
            Contact contact = new Contact();
            contact.ContactID = 1;
            contact.FirstName = "Farhat";
            contact.LastName = "Pirzada";
            contact.Email = "fiji@lizi.com";
            contact.PhoneNumber = "112-233-4455";
            contact.Status = (int)ContactStatus.InActive;
            var result = (RedirectToRouteResult)controller.Edit(contact);
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [TestMethod]
        public void TestDeleteView()
        {
            var controller = new ContactsController();
            var result = controller.Delete(1) as ViewResult;
            var contact = (Contact)result.ViewData.Model;
            Assert.AreEqual("Farhat", contact.FirstName);
        }

        [TestMethod]
        public void TestDeleteRedirect()
        {
            var controller = new ContactsController();
            Contact contact = new Contact();
            contact.ContactID = 1;
            var result = (RedirectToRouteResult)controller.Delete(contact);
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Logic;
using ProtalOfLife.Models.Data;
using ProtalOfLife.Models.Responses;

namespace ProtalOfLife.Tests
{
    [TestFixture]
    public class InMemoreyTests
    {
        [TestCase("Name", "Content", true)]
        [TestCase("Name", "", false)]
        [TestCase("", "Content", false)]
        [TestCase("NewName", "Content", true)]
        [TestCase("Name", "NewContent", true)]

        public void CanAddPolicy(string name, string content, bool expectedResult)
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            Policy policy = new Policy();
            policy.Name = name;
            policy.Content = content;
            PolicyResponse response = grinder.AddNewPolicy(policy);
            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("Healthcare", "", true)]
        [TestCase("", "content", false)]
        [TestCase("", "Content", false)]
        [TestCase("Retirement", "", true)]
        [TestCase("not a real policy", "NewContent", false)]

        public void CanDeletePolicy(string name, string content, bool expectedResults)
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            Policy policy = new Policy();
            policy.Name = name;
            policy.Content = content;
            PolicyResponse response = grinder.DeletePolicy(policy);
            Assert.AreEqual(expectedResults, response.Success);
        }

        [TestCase("", false)]
        [TestCase("Name", true)]
        [TestCase("", false)]
        [TestCase("NewName", true)]

        public void CanAddCategory(string name, bool expectedResults)
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            Category category = new Category();
            category.Name = name;
            CategoryResponse response = grinder.AddNewCategory(category);
            Assert.AreEqual(expectedResults, response.Success);
        }

        [TestCase("", false)]
        [TestCase("Code of Conduct", true)]
        [TestCase("Not real Category", false)]
        [TestCase("", false)]
        [TestCase("Benefits", true)]

        public void CanDeleteCategory(string name, bool expectedResults)
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            Category category = new Category();
            category.Name = name;
            CategoryResponse response = grinder.DeleteCategory(category.Name);
            Assert.AreEqual(expectedResults, response.Success);
        }

        [TestCase("", false)]
        [TestCase("Workplace Expectations", true)]
        [TestCase("", false)]
        [TestCase("Healthcare", true)]

        public void CanSearchOnePolicy(string name, bool expectedResults)
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            Policy policy = new Policy();
            policy.Name = name;
            PolicyResponse response = grinder.GetOnePolicy(policy);
            Assert.AreEqual(expectedResults, response.Success);
        }
    }
}

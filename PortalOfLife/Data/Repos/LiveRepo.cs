using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtalOfLife.Models.Data;
using System.IO;
using System.Xml.Serialization;
using Data.Models;

namespace Data.Repos
{
    public class LiveRepo : ICategoryRepository
    {
        const string _filePath = @"C:\Users\apprentice\Documents\HRCategories.xml";

        public bool AddCategory(Category category)
        {
            var dataBase = Open();
            if (!dataBase.Categories.Any(c => c.Name == category.Name))
            {
                category.Id = dataBase.Categories.Count();
                dataBase.Categories.Add(category);
                Close(dataBase);
                return true;
            }
            Close(dataBase);
            return false;
        }

        public bool AddPolicy(Policy policy)
        {
            var database = Open();
            foreach (var category in database.Categories)
            {
                if (category.Id == policy.CategoryId)
                {
                    category.Policies.Add(policy);
                    Close(database);
                    return true;
                }
            }
            Close(database);
            return false;
        }

        public bool DeleteCategory(string name)
        {
            var dataBase = Open();
            foreach (var category in dataBase.Categories)
            {
                if (category.Name == name)
                {
                    dataBase.Categories.Remove(category);
                    Close(dataBase);
                    return true;
                }
            }
            Close(dataBase);
            return false;
        }

        public Category Get(string name)
        {
            IEnumerable<Category> categoryList = GetAll();
            Category category = categoryList.FirstOrDefault(c => c.Name == name);
            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            return Open().Categories;
        }

        public Policy GetPolicy(Policy policy)
        {
            var dataBase = Open();
            foreach (var category in dataBase.Categories)
            {
                foreach (var item in category.Policies)
                {
                    if (item.Name == policy.Name)
                    {
                        Close(dataBase);
                        return item;
                    }
                }
            }
            Close(dataBase);
            return policy;
        }

        public bool RemovePolicy(Policy policy)
        {
            var dataBase = Open();
            foreach (var category in dataBase.Categories)
            {
                foreach (var item in category.Policies)
                {
                    if (item.Name == policy.Name)
                    {
                        category.Policies.Remove(item);
                        Close(dataBase);
                        return true;
                    }
                }
            }
            Close(dataBase);
            return false;
        }

        public DatabaseContainer Open()
        {
            if (!File.Exists(_filePath))
            {
                Close(new DatabaseContainer());
            }
            XmlSerializer serializer = new XmlSerializer(typeof(DatabaseContainer));
            using (Stream reader = new FileStream(_filePath, FileMode.Open))
            {
                return (DatabaseContainer)serializer.Deserialize(reader);
            }
        }

        public void Close(DatabaseContainer categoryList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DatabaseContainer));
            Stream writer = new FileStream(_filePath, FileMode.Create);
            serializer.Serialize(writer, categoryList);
            writer.Close();
        }
    }
}

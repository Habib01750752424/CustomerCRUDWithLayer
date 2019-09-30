using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerCRUD.Repository;

namespace CustomerCRUD.BLL
{
    public class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();
        public bool Add(string name, string address, string contact)
        {
            return _itemRepository.Add(name,address,contact);
        }

        public bool isNameExist(string name)
        {
            return _itemRepository.isNameExist(name);
        }

        public bool CheckIfNumeric(string input)
        {
            return _itemRepository.CheckIfNumeric(input);
        }

        public DataTable Display()
        {
           return _itemRepository.Display();
        }

        public bool UpdateCustomer(int id, string name, string address, string contact)
        {
            return _itemRepository.UpdateCustomer(id,name,address,contact);
        }

        public bool Delete(int id)
        {
            return _itemRepository.Delete(id);
        }

        public DataTable Search(string name)
        {
            return _itemRepository.Search(name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class Repository
    {
        private Dictionary<int,Person> data;
         
        public Repository()
        {
            this.data = new Dictionary<int,Person>();    
        }
       
        public void Add(Person person)
        {
            data.Add(data.Count,person);
           
        }
        public Person Get(int id)
        {
            
            return  data[id];
        }
        public bool Update(int id,Person newPerson)
        {
            if (!data.ContainsKey(id))
            {
                return false; 
            }
            data[id] = newPerson;
            return true;
        }
        public bool Delete(int id)
        {
            if (!data.ContainsKey(id))
            {
                return false;
            }
            data.Remove(id);
            return true;
        }
        public int Count()
        {
            return data.Count();
        }
    }
}

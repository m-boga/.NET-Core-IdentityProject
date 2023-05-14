using IdentityProject.DataAccessLayer.Abstract;
using IdentityProject.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProject.DataAccessLayer.Repositories
{
    /*
     * Bu kod satırı, "GenericRepository" adında bir sınıfı tanımlar. 
     * Sınıf, "IGenericDal" arayüzünü uygular ve "T" tipinde bir parametre alır. 
     * "where T : class" ifadesiyle, "T" parametresinin referans tip bir sınıf olması gerektiği belirtilir. 
     * Yani, "T" herhangi bir sınıf tipi olabilir, ancak değer tiplerini kabul etmez.

        Bu yapı, bir genel veritabanı işlem sınıfı tasarlamak için kullanılabilir.
        "T" parametresi, farklı sınıfların veritabanı işlemlerini gerçekleştirmek için kullanılan tipi temsil eder.
        Bu sayede, aynı kodu farklı tipler için tekrar tekrar yazmak yerine, 
        genel bir sınıf kullanarak tekrar kullanılabilirlik sağlanır.*/
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var context = new Context();
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }

        // Belirli bir kimliğe sahip veriyi veritabanından alır
        public T GetByID(int id)
        {
            using var context = new Context();
            return context.Set<T>().Find(id);
        }
        
        // Tüm verileri veritabanından alır ve bir liste olarak döndürür
        public List<T> GetList()
        {
            using var context = new Context();
            return context.Set<T>().ToList();
        }

        // Yeni bir veri ekler
        public void Insert(T t)
        {
            using var context = new Context();
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        // Var olan bir veriyi günceller
        public void Update(T t)
        {
            using var context = new Context();
            context.Set<T>().Update(t);
            context.SaveChanges();
        }
    }
}

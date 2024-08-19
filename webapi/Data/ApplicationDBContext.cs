using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class ApplicationDBContext :DbContext{
         public ApplicationDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
         {
           /*  Bu yapıcı metot, DbContextOptions türünde bir parametre alır ve bu parametreyi base sınıfa (DbContext) iletir. DbContextOptions, veritabanı bağlantı seçeneklerini yapılandırmak için kullanılır. Örneğin, hangi veritabanı sağlayıcısını (SQL Server, SQLite, vb.) kullanacağınızı bu seçenekler belirler. (dbContextOptions): Bu ifade, DbContext'in yapılandırma seçeneklerini ApplicationDBContext sınıfına aktarır.*/
         }
         public DbSet<Stock> Stock{get; set;}
         //DbSet<Stock>, veritabanındaki Stock tablosunu temsil eder. Bu tablo üzerinde CRUD (Create, Read, Update, Delete) işlemleri yapmak için kullanılır.
         public DbSet<Comment> Comment{get; set;}
    }
    
}
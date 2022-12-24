using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category(){ID=1,CategoryName = "Electronic", Description = "Electronic Products"},
                new Category(){ID=2,CategoryName = "Fashion", Description = "Fashion Products"},
                new Category(){ID=3, CategoryName = "Home,Life", Description = "Home,Life Products"},
                new Category(){ID=4,CategoryName = "Sport,Outdoor", Description = "Sport,Outdoor Products"},
                new Category(){ID=5, CategoryName = "Cosmetics,Personal Care", Description = "Cosmetics,Personal CareProducts"},
                new Category(){ID=6, CategoryName = "Book,Music.Movie", Description = "Book,Music.Movie CareProducts"}
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){ ProductName = "Iphone 14 Pro",ProductDescription = "iOS 16, Kilit Ekranı’nızı yepyeni ve eğlenceli yollarla kişiselleştirmenize imkan sağlıyor. Daha dikkat çekici olması için fotoğrafınızı öne çıkarın. Aktivite halkalarınızı takip edin. Ve sevdiğiniz uygulamalardan gelen gerçek zamanlı güncellemeleri görün.",PictureURL="https://productimages.hepsiburada.net/s/280/1500/110000267190528.jpg", UnitPrice =1200 , ProductAvailable =true , CategoryID = 1,IsPromoted = true},
                new Product(){ ProductName = "Iphone 14 Pro",ProductDescription = "iOS 16, Kilit Ekranı’nızı yepyeni ve eğlenceli yollarla kişiselleştirmenize imkan sağlıyor. Daha dikkat çekici olması için fotoğrafınızı öne çıkarın. Aktivite halkalarınızı takip edin. Ve sevdiğiniz uygulamalardan gelen gerçek zamanlı güncellemeleri görün.",PictureURL="https://productimages.hepsiburada.net/s/280/1500/110000267190528.jpg", UnitPrice =1200 , ProductAvailable =true , CategoryID = 1,IsPromoted = true},
                new Product(){ ProductName = "Canon Eos 700D 18-55 DC DSLR Fotoğraf Makinesi",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =1200 , ProductAvailable =false , CategoryID = 1,IsPromoted = true},
                new Product(){ ProductName = "Canon Eos 100D 18-55 mm IS STM Kit DSLR Fotoğraf Makinesi",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =1200 , ProductAvailable =true , CategoryID = 1,IsPromoted = true},
                new Product(){ ProductName = "Canon Eos 700D + 18-55 Is Stm + Çanta + 16 Gb Hafıza Kartı",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =1200  , ProductAvailable =false , CategoryID = 1},

                new Product(){ ProductName = "Dell Inspiron 5567 Intel Core i5 7200U 8GB 1TB R7 M445 Windows 10 Home 15.6 FHD Taşınabilir Bilgisayar FHDG20W81C", UnitPrice =1200 , ProductAvailable =true , CategoryID = 2},
                new Product(){ ProductName = "Lenovo Ideapad 310 Intel Core i7 7500U 12GB 1TB GT920M Windows 10 Home 15.6 Taşınabilir Bilgisayar 80TV028XTX",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =4500  , ProductAvailable =true , CategoryID = 2,IsPromoted = true},
                new Product(){ ProductName = "Asus UX310UQ-FB418T Intel Core i7 7500U 8GB 512GB SSD GT940MX Windows 10 Home 13.3 QHD Taşınabilir Bilgisayar",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =3400 , ProductAvailable =true , CategoryID = 2,IsPromoted = true},
                new Product(){ ProductName = "Asus UX310UQ-FB418T Intel Core i7 7500U 16GB 512GB SSD GT940MX Windows 10 Home 13.3 QHD Taşınabilir Bilgisayar",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =2500 , ProductAvailable =true , CategoryID = 2},
                new Product(){ ProductName = "Asus N580VD-DM160T Intel Core i7 7700HQ 16GB 1TB + 128GB SSD GTX1050 Windows 10 Home",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =5200  , ProductAvailable =true , CategoryID = 2},

                new Product(){ ProductName = "LG 49UH610V 49 124 Ekran 4K Uydu Alıcılı Smart LED TV", UnitPrice =1200  , ProductAvailable =true , CategoryID = 3},
                new Product(){ ProductName = "Vestel 49UB8300 49 124 Ekran 4K Smart Led Tv",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =5600  , ProductAvailable =true , CategoryID = 3},
                new Product(){ ProductName = "Samsung 55KU7500 55 140 Ekran [4K] Uydu Alıcılı Smart[Tizen] LED TV",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =3400 , ProductAvailable =false , CategoryID =3,IsPromoted = true},
                new Product(){ ProductName = "LG 55UH615V 55 140 Ekran 4K Uydu Alıcılı Smart Wi-Fi [webOS 3.0] LED TV",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =2500 , ProductAvailable =true , CategoryID = 3,IsPromoted = true},
                new Product(){ ProductName = "Sony Kd-55Xd7005B 55 140 Ekran [4K] Uydu Alıcılı Smart LED TV",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =5200  , ProductAvailable =true , CategoryID = 3},

                new Product(){ ProductName = "Apple iPhone 6 32 GB (Apple Türkiye Garantili)", ProductDescription ="", ProductAvailable =true , CategoryID = 4},
                new Product(){ ProductName = "Apple iPhone 7 32 GB (Apple Türkiye Garantili)",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =5600  , ProductAvailable =true , CategoryID = 4,IsPromoted = true},
                new Product(){ ProductName = "Apple iPhone 6S 32 GB (Apple Türkiye Garantili)",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =3400 , ProductAvailable =false , CategoryID =4,IsPromoted = true},
                new Product(){ ProductName = "Case 4U Manyetik Mıknatıslı Araç İçi Telefon Tutucu",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =2500 , ProductAvailable =true , CategoryID = 4},
                new Product(){ ProductName = "Xiaomi Mi 5S 64GB (İthalatçı Garantili)",ProductDescription = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UnitPrice =520 , ProductAvailable =true , CategoryID = 4},

            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
﻿using System;
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
                new Category(){Name = "Electronic", Description = "Electronic Products"},
                new Category(){Name = "Fashion", Description = "Fashion Products"},
                new Category(){Name = "Home,Life", Description = "Home,Life Products"},
                new Category(){Name = "Sport,Outdoor", Description = "Sport,Outdoor Products"},
                new Category(){Name = "Cosmetics,Personal Care", Description = "Cosmetics,Personal CareProducts"},
                new Category(){Name = "Book,Music.Movie", Description = "Book,Music.Movie CareProducts"}
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){ Name = "Iphone 14 Pro", Description = "iOS 16, Kilit Ekranı’nızı yepyeni ve eğlenceli yollarla kişiselleştirmenize imkan sağlıyor. Daha dikkat çekici olması için fotoğrafınızı öne çıkarın. Aktivite halkalarınızı takip edin. Ve sevdiğiniz uygulamalardan gelen gerçek zamanlı güncellemeleri görün.",Image="https://productimages.hepsiburada.net/s/280/1500/110000267190528.jpg", Price =1200 , ProductAvailable =true , CategoryId = 1,IsHome = true},
                new Product(){ Name = "Iphone 14 Pro", Description = "iOS 16, Kilit Ekranı’nızı yepyeni ve eğlenceli yollarla kişiselleştirmenize imkan sağlıyor. Daha dikkat çekici olması için fotoğrafınızı öne çıkarın. Aktivite halkalarınızı takip edin. Ve sevdiğiniz uygulamalardan gelen gerçek zamanlı güncellemeleri görün.",Image="https://productimages.hepsiburada.net/s/7/550/8914083512370.jpg", Price =1200 , ProductAvailable =true , CategoryId = 1,IsHome = true},
                new Product(){ Name = "Canon Eos 700D 18-55 DC DSLR Fotoğraf Makinesi", Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =1200 , ProductAvailable =false , CategoryId = 1,IsHome = true},
                new Product(){ Name = "Canon Eos 100D 18-55 mm IS STM Kit DSLR Fotoğraf Makinesi", Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =1200 , ProductAvailable =true , CategoryId = 1,IsHome = true},
                new Product(){ Name = "Canon Eos 700D + 18-55 Is Stm + Çanta + 16 Gb Hafıza Kartı", Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =1200  , ProductAvailable =false , CategoryId = 1},

                new Product(){ Name = "Dell Inspiron 5567 Intel Core i5 7200U 8GB 1TB R7 M445 Windows 10 Home 15.6 FHD Taşınabilir Bilgisayar FHDG20W81C", Price =1200 , ProductAvailable =true , CategoryId = 2},
                new Product(){ Name = "Lenovo Ideapad 310 Intel Core i7 7500U 12GB 1TB GT920M Windows 10 Home 15.6 Taşınabilir Bilgisayar 80TV028XTX",Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =4500  , ProductAvailable =true , CategoryId = 2,IsHome = true},
                new Product(){ Name = "Asus UX310UQ-FB418T Intel Core i7 7500U 8GB 512GB SSD GT940MX Windows 10 Home 13.3 QHD Taşınabilir Bilgisayar",Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =3400 , ProductAvailable =true , CategoryId = 2,IsHome = true},
                new Product(){ Name = "Asus UX310UQ-FB418T Intel Core i7 7500U 16GB 512GB SSD GT940MX Windows 10 Home 13.3 QHD Taşınabilir Bilgisayar",Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =2500 , ProductAvailable =true , CategoryId = 2},
                new Product(){ Name = "Asus N580VD-DM160T Intel Core i7 7700HQ 16GB 1TB + 128GB SSD GTX1050 Windows 10 Home",Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =5200  , ProductAvailable =true , CategoryId = 2},

                new Product(){ Name = "LG 49UH610V 49 124 Ekran 4K Uydu Alıcılı Smart LED TV", Price =1200  , ProductAvailable =true , CategoryId = 3},
                new Product(){ Name = "Vestel 49UB8300 49 124 Ekran 4K Smart Led Tv",Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =5600  , ProductAvailable =true , CategoryId = 3},
                new Product(){ Name = "Samsung 55KU7500 55 140 Ekran [4K] Uydu Alıcılı Smart[Tizen] LED TV",Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =3400 , ProductAvailable =false , CategoryId =3,IsHome = true},
                new Product(){ Name = "LG 55UH615V 55 140 Ekran 4K Uydu Alıcılı Smart Wi-Fi [webOS 3.0] LED TV",Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =2500 , ProductAvailable =true , CategoryId = 3,IsHome = true},
                new Product(){ Name = "Sony Kd-55Xd7005B 55 140 Ekran [4K] Uydu Alıcılı Smart LED TV",Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =5200  , ProductAvailable =true , CategoryId = 3},

                new Product(){ Name = "Apple iPhone 6 32 GB (Apple Türkiye Garantili)", Description ="", ProductAvailable =true , CategoryId = 4},
                new Product(){ Name = "Apple iPhone 7 32 GB (Apple Türkiye Garantili)",Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =5600  , ProductAvailable =true , CategoryId = 4,IsHome = true},
                new Product(){ Name = "Apple iPhone 6S 32 GB (Apple Türkiye Garantili)",Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =3400 , ProductAvailable =false , CategoryId =4,IsHome = true},
                new Product(){ Name = "Case 4U Manyetik Mıknatıslı Araç İçi Telefon Tutucu",Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =2500 , ProductAvailable =true , CategoryId = 4},
                new Product(){ Name = "Xiaomi Mi 5S 64GB (İthalatçı Garantili)",Description = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", Price =520 , ProductAvailable =true , CategoryId = 4},

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
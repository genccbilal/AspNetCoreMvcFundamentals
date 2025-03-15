# AspNetCoreMvcFundamentals 🚀  
- Bu proje, Udemy de izlemiş olduğum kurs kapsamında öğrendiğim ASP.NET Core MVC konularını pekiştirmek amacıyla geliştirdiğim bir öğrenme ve demo uygulamasıdır. İçeriğinde temel CRUD işlemleri, middleware kullanımı, dosya ve klasör işlemleri gibi konular bulunmaktadır.
- 
## 📌 Proje İçeriği  
- **MVC Yapısı**: Controller, Model, View yapıları 
- **CRUD İşlemleri**: Veritabanı bağlantısı olmadan temel CRUD operasyonları
- **Session Kullanımı**:  Kullanıcı oturum verilerini yönetme  
- **Middleware Kullanımı**: Request ve Response manipülasyonu yapan Middleware'ler
- **Areas Yapısı**: Admin ve Member gibi alan bazlı yönetim sistemi
- **ViewComponent Kullanımı**: Dinamik bileşenler oluşturma
- **Dosya ve Klasör İşlemleri**: Dosya ve klasör yönetimi  

---

## 📁 Proje Yapısı

- 📂 Areas → Admin ve Member gibi farklı yönetim panelleri içerir.
- 📂 Controllers → MVC Controller’ları bulunur (ProductController, SessionController, vb.)
- 📂 Middlewares → Özel Request ve Response Middleware dosyaları bulunur.
- 📂 Models → Customer, News gibi veri modelleri bulunur.
- 📂 Pages → Razor Pages ile çalışan sayfalar bulunur.
- 📂 ViewComponents → News bileşeni gibi modüler yapıdaki bileşenler içerir.
- 📂 Views → MVC View dosyaları bulunur.
- 📄 appsettings.json → Konfigürasyon dosyasıdır.
- 📄 Startup.cs → Servisleri ve Middleware’leri yapılandıran dosya.
- 📄 Program.cs # Ana uygulama dosyası


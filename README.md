# 📘 Blog API Projesi

Bu proje, ASP.NET Core kullanılarak geliştirilmiş basit bir Blog API uygulamasıdır. Kullanıcılar, blog yazıları oluşturabilir, güncelleyebilir, silebilir ve yazılara yorum yapabilir. Amaç, Entity Framework Core ve RESTful API prensiplerini kullanarak CRUD işlemlerini pratik etmektir.

---

## 🚀 Kullanılan Teknolojiler

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (API dokümantasyonu)
- AutoMapper

---

## 🔧 Proje Özellikleri

- Blog yazısı oluşturma, listeleme, güncelleme ve silme (CRUD)
- Her yazıya ait yorumları listeleme ve yorum ekleme
- Swagger UI ile test edilebilir API yapısı

---

## 📁 Katmanlı Mimari

Proje üç ana katmandan oluşur:

- **Entities Katmanı**: Model sınıflarını içerir.
- **DataAccess Katmanı**: Repository yapısı ile veri erişimi sağlanır.
- **WebAPI Katmanı**: Controller yapıları ve API uç noktaları burada yer alır.

---

## 🧱 Veritabanı Modelleri

### Post
```csharp
public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Comment> Comments { get; set; }
}
```

### Comment
```csharp
public class Comment
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string CommentText { get; set; }
    public DateTime CommentedAt { get; set; }
    public Post Post { get; set; }
}
```

---

## 📌 API Uç Noktalarından Bazıları

### Yazılar
- `GET /api/posts` : Tüm yazıları getirir.
- `GET /api/posts/{id}` : Belirli ID'ye sahip yazıyı getirir.
- `POST /api/posts` : Yeni yazı oluşturur.
- `PUT /api/posts/{id}` : Yazıyı günceller.
- `DELETE /api/posts/{id}` : Yazıyı siler.

### Yorumlar
- `GET /api/comments/post/{postId}` : Bir yazıya ait tüm yorumları getirir.
- `POST /api/comments` : Yeni yorum ekler.

---

## 🧪 Swagger Arayüzü

Proje çalıştırıldığında [http://localhost:{port}/swagger](http://localhost:{port}/swagger) adresinden Swagger arayüzüne erişerek API'nizi test edebilirsiniz.

---

## 📌 Nasıl Çalıştırılır?

1. Projeyi klonlayın:
```bash
git clone https://github.com/mertagralii/BlogAPI.git
```
2. Visual Studio ile açın.
3. `appsettings.json` dosyasından veritabanı bağlantınızı yapılandırın.
4. Migration ve database oluşturun:
```bash
dotnet ef database update
```
5. Projeyi çalıştırın ve Swagger'dan test edin.

---

## ✨ Katkıda Bulunmak

Katkılarınızı memnuniyetle kabul ederim. Forklayarak PR atabilirsiniz!

---

## 👤 Geliştirici

[Mert Ağralı](https://github.com/mertagralii)

---

Projeyi incelediğiniz için teşekkür ederim! ✨

# MassTransit Patterns with RabbitMQ

Bu repository, .NET dünyasında en popüler mesaj bus kütüphanelerinden biri olan **MassTransit** kullanılarak RabbitMQ üzerinde uygulanan ileri seviye mesajlaşma desenlerini içermektedir.



## Proje İçeriği

Bu çalışma kapsamında aşağıdaki temel senaryolar simüle edilmiştir:

### 1. Basic Send/Receive
Mesajların belirli bir kuyruğa (`ISendEndpoint`) doğrudan gönderilmesi ve bir `Consumer` tarafından karşılanması. Saf RabbitMQ'daki P2P modelinin MassTransit ile soyutlanmış halidir.

### 2. Request/Response Pattern
İstemcinin (`RequestClient`) bir talep gönderdiği ve sunucudan bir yanıt (`ResponseMessage`) beklediği asenkron ama çift yönlü iletişim modelidir. MassTransit bu süreçteki `CorrelationId` ve geçici kuyruk yönetimini otomatikleştirir.

### 3. Worker Service Integration
.NET Background Service (Worker Service) mimarisi içinde MassTransit entegrasyonu. Bu bölümde `IPublishEndpoint` kullanılarak mesajların nasıl yayımlandığı ve `AddMassTransit` konfigürasyonuyla servislerin nasıl yönetildiği gösterilmektedir.

## Teknik Detaylar
*   **MassTransit:** Mesajlaşma altyapısı için yüksek seviyeli soyutlama sağlar.
*   **RabbitMQ:** Mesaj taşıyıcı (broker) olarak görev yapar.
*   **.NET 9 & Worker Services:** Modern arka plan görevleri ve bağımlılık enjeksiyonu (DI) kullanımı.

## Klasör Yapısı
- **MassTransit.Publisher/Consumer:** Temel gönder-al işlemleri.
- **MassTransit.RequestResponsePattern:** İleri seviye istek-yanıt senaryosu.
- **MassTransit.WorkerService:** Gerçek zamanlı arka plan servis uygulamaları.
- **MassTransit.Shared:** Mesaj kontratlarının (Interface/Class) ortak yönetildiği kütüphane.

## ⚙️ Kurulum ve Çalıştırma

1. Projeyi klonlayın.
2. `MassTransit.Shared` projesinin "Class Library" olarak derlendiğinden emin olun.
3. İlgili `Program.cs` dosyalarındaki `rabbitMQUri` değişkenini kendi RabbitMQ bağlantı adresinizle güncelleyin.
4. Önce **Consumer** (veya Worker Service) projelerini, ardından **Publisher** projelerini başlatın.

## Neden MassTransit?
Saf RabbitMQ Client kullanımına kıyasla MassTransit; hata yönetimi (retry), kuyrukların otomatik oluşturulması, mesaj serileştirme ve kolay test edilebilirlik gibi avantajlar sunar.

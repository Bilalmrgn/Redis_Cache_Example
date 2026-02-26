.NET Cache Implementation Examples
Bu proje, .NET üzerinde In-Memory Caching ve Distributed Caching (Redis) yöntemlerinin temel uygulamalarını içeren bir eğitim ve referans çalışmasıdır.

📁 Proje Yapısı
✅Solution içerisinde iki ana proje bulunmaktadır:

✅InMemory.Caching: Uygulamanın çalıştığı sunucunun RAM'ini kullanarak veri saklama yöntemi.
✅Distributed.Caching: Bağımsız bir veri deposu (örneğin Redis) kullanarak, farklı instance'lar arasında paylaşılan veri saklama yöntemi.

🚀 Başlıca Özellikler

1. In-Memory Caching
✅Sunucu belleğinde hızlı veri erişimi sağlar. Tekil sunucu mimarileri için idealdir.
✅Absolute Expiration: Verinin bellekte kalacağı kesin süre (örn: 30 saniye).
✅Sliding Expiration: Veriye erişilmediği takdirde silinme süresi (her erişimde süre sıfırlanır).
✅IMemoryCache arayüzü ile bağımlılık enjeksiyonu (DI).

2. Distributed Caching
✅Veriler harici bir katmanda tutulur. Uygulama kapansa bile veri korunur ve birden fazla sunucu aynı cache'e erişebilir.
✅IDistributedCache arayüzü kullanımı.
✅String ve Binary (byte[]) formatında veri saklama.
✅Karmaşık veri tipleri için Encoding.UTF8 ile veri işleme.

🛠️ Teknolojiler
✅.NET 6.0
✅ASP.NET Core Web API
✅Microsoft.Extensions.Caching.Memory
✅Microsoft.Extensions.Caching.StackExchangeRedis (Distributed tarafı için altyapı)

Projeyi klonlayın:
Bash
✅git clone https://github.com/Bilalmrgn/Redis_Cache_Example.git

Distributed Cache (Redis) kısmını test etmek için sisteminizde bir Redis instance'ı çalıştığından emin olun veya Program.cs içindeki konfigürasyonu kontrol edin.

Projeyi çalıştırın:

Bash
✅dotnet run
Hazırlayan: Bilal Emir Mergen

Bu proje, caching stratejilerinin farklarını ve uygulama yöntemlerini anlamak amacıyla geliştirilmiştir.

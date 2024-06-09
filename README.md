# Simofun
## Case 1: Dependency Inversion
### Tasarım Prensipleri - SOLID
- Dependency Inversion prensibine göre sınıflar birbiri ile soyut(abstract) bir şekilde bağımlı olmalıdır. Böylelikle iki sınıfın yakın bağıtınlı(close-coupled) olmasının önüne geçilmiş olur.
- Bu sebeple "ILeaderboardSorter" interface'i oluşturulmuş ve "LeaderboardSorterByName" "LeaderboardSorterByScore" sınıflarının bu inteface'i uygulaması sağlanmıştır. 
- Böylelikle "LeaderboardController" sınıfının bu 2 sınıfa olan bağımlılığı azaltılmıştır.

- Ayrıca "ILeaderboardProvider" interface'i oluşturulmuş ve  "FakeLeaderboardProvider"  sınıfının bu interface'i uygualamsı sağlanmıştır. 
- Böylelikle "LeaderboardController" sınıfının "FakeLeaderboardProvider" sınıfına olan bağımlılığı azaltılmıştır.

### Tasarım Desenleri 
- Tasarım deseni olarak ise "ILeaderboardProvider" GetItems fonksiyonu için Factory Pattern kullanmayı düşündüm. Fakat dönen değerler çok kompleks yapıda olmadığı için aşırı mühendislik(over engineering) olacağına kanaat getirdim.
- Projenin kapsamının nasıl genişleyeceği belirlendikten sonra hangi tasarım desenlerinin uygulanması gerektiği konusunda fikir belirtmenin daha sağlıklı olacağını düşünüyorum. 
(Genel olarak kullandığım tasarım desenleri: Factory, Builder, Observer, Service Locator, State, Command, Dependency Injection, Object Pool)
(Daha kapsamlı bir projemi bırakıyorum: https://github.com/canernurdag/Unity_BattleRoyale_SinglePlayer)

## Case2: Drag Release To Throw
- https://www.youtube.com/shorts/g_5Qc4YwOJQ
- https://www.youtube.com/shorts/4FLBKBPETEM
- İlk frame ile birlikte fırlatılacak olan top sahnede yaratılmaktadır.
- Kullanıcının elini kaldırmadan ilk dokunduğu nokta ve son dokuduğu nokta yardımıyla bir dragVector'u hesaplanmaktadır.
- Bu vektöre göre atış öncesi hız büyüklüğü ve mevcut doğrultusu hesaplanmakta, ardından ise bir WorldCanvas aracılığı ile bu vektör kullanıcıya UX olarak anlatılmaktadır. 
- Yine bu hız büyüklüğü ve doğrultu kullanılarak fırlatılacak topun rigidbody'sine belirlenen kuvvet uygulanmaktadır.
- Genel olarak basit bir event sistemi aracılığıyla ve [Serializefield] attribute'u ile obje iletişimleri sağlanmıştır.
- Yine event sistemi ve interface'ler aracılığı ile objeler arasındaki bağımlılık azaltılmıştır. 
- Cinemachine'e çok alışkın olduğum için, kamera sistemi olarak Cinemachine StateDrivenCamera kullanılmıştır. 
- Oyunda eğer kırmızı deliğe dokunursak "SUCCESS", platformdan aşağı düşersek ise "FAIL" olmaktadır.

## Case3: Drag To Clean
- https://www.youtube.com/shorts/Ab4e8rLSGnI
- Blender ve Photosop aracılığı ile model ve texture'lar hazırlanmıştır.
- Modelin UV'si açılırken arada boşluk olacak şekilde ayarlanmıştır. Böylece atlamalı bir boyama görüntüsünün önüne geçilmiştir.
- Photoshop'da 3 adet texture hazırlanmıştır: "Temiz Texture", "Kirli Texture" ve "Yeşil&Siyah" pixel rengi değiştirilecek olan Texture. 
- Kameradan fırlatılan Raycast objeye çarpıyorsa; temizleyici objenin posizsyonu hit pozisyona, temizleyici objenin rotasyonu hit pozisyonunun normali ile hesaplanan rotasyona yumuşak geçiş olacak şekilde ayarlanmıştır.
- Ayrıca Raycast'in objeye çarptığı noktadaki pixel'in pozisyonu hesaplanmış ve daha sonra bu pozison merkez olacak şekilde, brush texture'ı ile Yeşil&Siyah olan texture'da gerekli pixel manipulasyon işlemi gerçekleştirilmiştir.
- Ve son olarak ne kadarlık pixel manipule edildiği % olarak Ui'da kullanıcıya belirtilmiştir.
- Eğer %95'i geçerse "SUCCESS"
- Not: Genelde pixel rengi değiştirmek için Paint In 3D assetini kullanıyorum.

## Case4: Tap Drag To Sort
- https://www.youtube.com/shorts/yqXp-XAw6d0
- Öncelikle editor kodu yazarak, hızlı bir şekilde level dizme kolaylığı sağlanmıştır.
- Dolu bir slota dokunulduğu zaman, içindeki obje biz bırakana kadar input ile beraber sürüklenmektedir.
- Input'u bıraktığımız anda eğer altta boş bir slot varsa, obje artık o slota geçmektedir.
- Input'u bıraktığımız anda eğer altta dolu bir slot varsa, obje ilk aldığımız slota geri dönmektedir. (Burada Swap mekaniği de uygulanabilir)
- Input'u bıraktığımız anda eğer altta slot hiç yoksa, obje ilk aldığımız slota geri dönmektedir.
- Obje her yer değiştirdiğinde, objenin içinde bulunduğu slot'un grubu önce kendi içinde doğruluk kontrolü yapmakta, daha sonra ise tüm slot gruplarında doğruluk kontrolu yapmaktadır.. 
- Eğer tüm gruplar aynı obje cinsinde olursa "SUCCESS" 

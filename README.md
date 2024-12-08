# SinergyIT_sorular_ve_cevaplar

1.	Saga pattern mikroservis mimarisinde hangi sorunları çözmeye çalışır?
> Distributed transaction yönetimi sorunlarına çözüm sunar. Distributed transaction, her servisin kendi veri tabanını yönetmesine denir. Geleneksel tek bir veritabanında transaction işlemleri kolayca yönetilebilirken, mikroservis mimarisinde her servis kendi veritabanına sahip olduğu için bu işlem karmaşıklaşır. Saga patternin bu karmaşıklıkta çözmeyi hedefeldiği sorunlar bunlardır:
> * <ins>Tutarlılık sağlama;</ins> Mikroservisler birbirinden bağımsız çalışması gerektiği için verilerin tutarlı kalması zor olur. Saga Pattern, her bir transaction adımının başarılı veya başarısız olmasına göre işlem akışını kontrol ederek tutarlılık sağlar.
> * <ins>Hata yönetimi;</ins> İşlem sırasında bir adım başarısız olduğunda, işlem zincirindeki önceki adımları geri almak gerekir. Saga Pattern, bu geri alma işlemleri için bir çözüm sunar.
> * <ins>Asenkron iletişim;</ins> sistem performansını senkron iletişim düşürür, ama asenkron iletişim sistemi bağımsız, tutarlı ve dayanıklı bir hale getirir. Mesela her servis kendi hızında çalışabilir, zincirleme gecikmeler yaşanmaz. Çünkü senkron çalışmak zorunda değiller.
> * <ins>Merkezi kontrolün olmaması;</ins> Mikroservis mimarisinde merkezi bir transaction yöneticisi bulunmadığı için, Saga Pattern distributed bir transaction yönetimi yaklaşımıyla bağımsız servislerin uyum içinde çalışmasını sağlar.
2.	Saga patterndeki choreography ve orchestration yaklaşımları arasındaki temel fark nedir?
>  İki yaklaşımda mikroservislerin birbirleriyle nasıl iletişim kurduğu ve transaction'ların nasıl yönetildiği konusunda farklı yöntemler sunar.
> | Choreography | Orchestration |
> | ------------- | ------------- |
> |![Microservice-Mimarilerde-Saga-Pattern-Ile-Transaction-Yonetimi](https://github.com/user-attachments/assets/157c0a61-6ea6-403a-81d1-cd773bd05d0c) | ![Microservice-Mimarilerde-Saga-Pattern-Ile-Transaction-Yonetimi-2](https://github.com/user-attachments/assets/f2eec8a6-6427-443f-9602-c941c71954ee) |
> | Mikroservisler kendi aralarında, doğrudan events aracılığıyla iletişim kurar. Her servis, bir event alır ve kendi işini yaptıktan sonra yeni bir event yayınlar. | Tüm işlem akışı bir orchestrator tarafından kontrol edilir. Bu, transaction adımlarının ve iş akışının kolayca izlenmesini sağlar. |
> | Merkezi kontrol yok | Merkezi kontrol var |
> | Servisler arası doğrudan iletişim | Orchestrator üzerinden iletişim |
> | Daha hızlı (asenkron iletişim)	 | Daha yavaş (senkron çağrılar gerekebilir) |
> | Daha bağımsız  | Daha bağımlı |

> Choreography, daha bağımsız ve asenkron bir yaklaşım iken, Orchestration ise daha merkezi ve takip edilebilir bir yaklaşımdır.
3.	Orchestration Saga pattern avantajları ve dezavantajları nelerdir?
> | Avantajlar  | Dezavantajlar |
> | ------------- | ------------- |
> |  Her bir servisin diğer servisle ilgili bilmesi gereken herhangi bir şeye ihtiyacı yoktur. Haliyle böylece Separation of Concerns(SoC) söz konusudur. Bağlılığı minimum tutup kolay ürün çıkarmayı sağlar. | Orchestration implemantasyonunun tek dezavantajı tüm iş akışının yönetiminin Saga Orchestrator tarafından gerçekleştiriliyor olmasıdır. |
> | Hata yönetimi kolaydır. Bir işlem başarısız olduğunda geri alma işlemi ile sorun çözülür. |   |
> | Tüm işlem akışı bir orchestrator tarafından kontrol edilir. Bu şekilde iş akışını izlemek kolaylaşır. |  |
> | Orchestration implemantasyonu, tek taraflı olarak Saga servislere bağlı olduğu için döngüsel bağımlılık yoktur.  |  |
> | Uygulaması ve test etmesi choreography implemantasyonuna göre daha kolaydır.  |   |
4.	Bir e-ticaret uygulaması tasarladığınızı düşünelim. Bu uygulamada müşteriler sipariş verdiklerinde, birden fazla hizmetin birlikte çalışması gerekiyor. Müşteri bir sipariş verdiğinde şu adımlar gerçekleşmeli:

* Stokta mevcut ürünleri kontrol eder ve onları rezerve eder.
* 	Müşterinin yeterli bakiye olup olmadığı kontrol edilir ve ödeme işlemi gerçekleştirilir.
* 	 Kargo ödeme onaylandıktan sonra gönderi için hazırlık yapar ve teslimat planlanır.

Burada dikkat etmeniz gereken bir nokta var: Eğer bu adımlardan herhangi biri başarısız olursa (örneğin, ödeme başarısız olursa veya stokta ürün yoksa), sistem önceki adımları geri alarak verilerin tutarlılığını sağlamalıdır. Yani, ödeme başarısız olursa stoktaki rezerv kaldırılmalı, kargo işlemi başarısız olursa ödeme iade edilmelidir..

4.1.	Bu süreci yönetmek için bir Saga pattern tasarlayın ve basit bir durum makinesi (state machine) diyagramı çizin. Sipariş Verildi aşamasından Sipariş Tamamlandı aşamasına kadar olan her bir durumu çizin ve her bir başarısızlık durumunda geri alma adımlarını gösterin.

4.2.	Her bir durumda, ilgili hizmetin başarılı ya da başarısız olması durumunda nasıl bir geçiş yapılacağını açıklayın.

>![image](https://github.com/user-attachments/assets/9a8bb539-fdc2-49f1-b1f6-71c39e724411)
>
>state machine diagramın işleyişi ve açıklaması
>
> 1.Siparişin Alınması ve İşleme Başlatılması (sipariş servisi)
> * Müşteri sipariş verdiğinde "Sipariş Servisi" bu talebi alır.
> * Sipariş durumu "Suspend" olarak kaydedilir.
> * Sipariş Saga Orchestrator'a ORDER_CREATED komutu gönderilir.
> * başarısızlık durumu beklenmez ama sistemsel bir hata oluşursa süreç başlatılmaz.
>
> 2. Stok Kontrolü ve Rezervasyonu ("Siparişi Hazırla (Sipariş Kanalı)" → Stok Servisi)
>
> * Saga Orchestrator, stok bilgilerini güncellemek için UPDATE_STOCK komutunu "Stok Servisi"ne gönderir.
> * Stok Servisi, stok rezervasyonunu yapar ve yine son durum başarılı ya da başarısız olarak orchestrator’a  bildirir.
> * başarılı olursa, stock servisi rezervasyonu yapar, orchestrator ödeme hazırlığını başlatır.
> * başarısız olursa, rezervasyon yapamaz, süreci sonlandırır.
>   
> 3. Ödeme İşlemi ("Ödemeyi Gerçekleştir (Ödeme Kanalı)" → Ödeme Servisi)
> * Saga Orchestrator, EXECUTE_PAYMENT komutunu "Ödeme Servisi"ne gönderir.
> * Ödeme Servisi, ödeme alındığına dair başarılı ya da başarısız bilgiyi tekrar Saga Orchestrator‘a döndürür.
> * başarılı olursa,ödeme gerçekleşir "Payment Completed" olur, Orchestrator stok kontrol işlemine geçer.
> * başarısız olursa, ödeme gerçekleşmez, orchestrator stock rezervasyonunu iptal eder.
>   
>  ![image](https://github.com/user-attachments/assets/cb161c76-21a7-4ef2-a3c8-c4b9d67cb5ab)
>   
> 4. Teslimat Hazırlığı ("Siparişi Teslim Et (Teslimat Kanalı)" → Teslimat Servisi)
>
> * Saga Orchestrator, teslimat işlemini başlatmak için ORDER_DELIVER komutunu "Teslimat Servisi"ne gönderir.
> * Teslimat Servisi, teslimat sürecini tamamlar ve  siparişin kargolandığı bilgisini başarılı yahut başarısız olarak Orchestrator'a bildirir.
> * başarılı olursa, teslimat gerçekleşir, süreç başarıyla sonlanır
> * başarısız olursa, teslimat gerçekleşmez, orchestrator ödemeyi iade eder ve stok rezervasyonunu iptal eder. Süreç sonlanır.
>   
> ![image](https://github.com/user-attachments/assets/e66b3728-d867-444c-8b8d-7705ae8eff58)
> 

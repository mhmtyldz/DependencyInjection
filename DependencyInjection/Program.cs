using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    //class Flight
    //{
    //    public void PegasusProvider(string sehir)
    //    {
    //        var result = "18:30 Dubai";
    //        Console.WriteLine("Uçus:" + result + "uçuşumuz vardır");
    //    }
    //    public void EmiratesProvider(string sehir)
    //    {
    //        var result = "18:30 Budapeşte";
    //        Console.WriteLine("Uçus:" + result + "uçuşumuz vardır");
    //    }
    //}
    //Bu Yazılan Program da çalışır ancak dinamik bir yapı oluşturmaz.
    //Dinamik Yapı oluşturmaz derken, başka sınıflara yada yapılara bağımlılıktan kurtarmak istiyorum,
    //Çünkü bu yapılan kod yapısı basit ilerki seviyelerde daha fazla koda bağımlı olduğunu düşünürsek 100  yerde belki daha fazla yerde değiştirme 
    //yapmam gerekecek bu da pek mümkün gözkümüyor. O yüzden Dependcy injection Kullanmalıyım.  O yüzden bitane interface sınıf tanımlayıp içine
    //Methodlarımı yazıyorum.


    interface IUcus //Bu interfaceden kalıtım alan tüm sınıflar doğal olarak interface'in kalıbını ve şartını sağlayacak
    {
        void PegasusProvider(string sehir);
        void EmiratesProvider(string sehir);
    }

    class Flight : IUcus
    {
        public void PegasusProvider(string sehir)
        {
            var result = "18:30 Dubai";
            Console.WriteLine("Uçus:" + result + "uçuşumuz vardır");
        }

        public void EmiratesProvider(string sehir)
        {
            var result = "18:30 Budapeşte";
            Console.WriteLine("Uçus:" + result + "uçuşumuz vardır");
        }
    }


    //Örneğin biz burda TurkishFlight Adı altında bi sınıf oluştursak  ve bunu IUcustan implementle methodları oluştursak.
    //Her hangi bi yeri değiştirmeye gerek duymuyoruz.Çünkü interfaceden implement ettiğimiz için tipi kendi seçiyor.
    class TurkishFlight : IUcus
    {
        public void PegasusProvider(string sehir)
        {
            var result = "18:30 Dubaiye";
            Console.WriteLine(sehir+"dan saat: "+result+" ye uçuş vardır");
        }

        public void EmiratesProvider(string sehir)
        {
            var result = "18:30 Budapeşteye";
            Console.WriteLine(sehir + "dan saat: " + result + " ye uçuş vardır");
        }
    }

    class UcacakAdam //Bunu oluşturma sebebimiz DI desenini uygulamak içindir. Burada fazla sınıf yada kod kalabalığı olabilir , 
        //Ancak ilerde bizi ağır bir yükten kurtaracaktır.
    {
        IUcus _ucus;
        public UcacakAdam(IUcus ucus)
        {
            _ucus = ucus;
        }

        public void Yazdır()
        {
            _ucus.EmiratesProvider("istanbul");
            _ucus.PegasusProvider("ankara");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Flight weather = new Flight();
            //weather.PegasusProvider("istanbul");

            UcacakAdam ucanadam = new UcacakAdam(new Flight());
            ucanadam.Yazdır();

            //UcacakAdam ucanadam2 = new UcacakAdam(new TurkishFlight());
            //ucanadam2.Yazdır();

        }
    }
}

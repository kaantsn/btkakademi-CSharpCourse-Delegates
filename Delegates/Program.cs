using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate void MyDelegate();
        public delegate void MyDelegate2(string text);
        public delegate int MyDelegate3(int number1, int number2);
        public class CustomerManager
        {
            public void SendMessage()
            {
                Console.WriteLine("Hello!");
            }

            public void ShowAlert()
            {
                Console.WriteLine("Be careful!");
            }

            public void SendMessage2(string message)
            {
                Console.WriteLine(message);
            }

            public void ShowAlert2(string alert)
            {
                Console.WriteLine(alert);
            }
        }

        public class Matematik
        {
            public int Topla(int sayi1, int sayi2)
            {
                return sayi1 + sayi2;
            }

            public int Carp(int sayi1, int sayi2)
            {
                return sayi1 * sayi2;
            }

        }
        static void Main(string[] args)
        {
            CustomerManager manager = new CustomerManager();
            //Class ile kullanım
            //manager.SendMessage(); 
            //manager.ShowAlert();

            //Delegate ile kullanım
            MyDelegate myDelegate = manager.SendMessage;
            myDelegate += manager.ShowAlert; // Sonradan ekleme yapılabilir.
            myDelegate -= manager.SendMessage; // Sonradan çıkarılabilir.

            MyDelegate2 myDelegate2 = manager.SendMessage2;
            myDelegate2 += manager.ShowAlert2;

            Matematik mat = new Matematik();
            MyDelegate3 myDelegate3 = mat.Topla;
            myDelegate3 += mat.Carp;
            var result = myDelegate3(2,3); // return içeren ifadelerde delgateler en son olan parametreye göre işlem yapar.

            Console.WriteLine(result);
            myDelegate2("BE CAREFUL!"); //parametreli olanlarda son yazılanı kabul eder. İkisinede aynı değeri göndermiiş oluruz.
            myDelegate();




            Console.ReadKey();
        }
    }
}

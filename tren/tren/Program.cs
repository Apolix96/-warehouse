using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tren
{
    // структура товара
   struct Tovar
    {
        //наименование
      
        public string nameTovar;
        public int price;
        public int kolTovar;
        
       
        public Tovar(string nmTr, string pc, string klTr)
        {
            
            if(pc == "")
            {
                pc = "0";
            }
                nameTovar = nmTr;
                price = Convert.ToInt32(pc);
                kolTovar = Convert.ToInt32(klTr);
            
        }
    }//end
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder("\t\t\t\tВариант №8\n");
            str.AppendLine("Написать программу, которая выполняет следующие действия:");
            str.AppendLine("1.	Ввод с клавиатуры или чтение из текстового файла данных в массив, состоящий из восьми элементов типа Tovar.");
            str.AppendLine("2.	Вывод записей, упорядоченных по возрастанию количества.");
            str.AppendLine("3.	Вывод информации о товарах, стоимостью более введенного с клавиатуры значения (если таких нет, то вывести соответствующее сообщение).");
            str.AppendLine("4.	Подсчитать общую стоимость всех товаров на складе.");

            Console.WriteLine(str.ToString());
            // для подсчета товаров на складе
            double summer = 0;
            // размер массива
            const int SizeTovar = 8;

            /*Как только будет использовано ключевое слово new, вызывается указанный конструктор*/
            Tovar[] tr = new Tovar[3];

            //переменные для передачи данных
            string nameTr;
            string kolTr;
            string priceTr;

            // -------------- заполнение значениями -----------------
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine("Введите наименование товара: "); nameTr = Console.ReadLine();
                Console.WriteLine("Введите стоимость товара: "); priceTr = Console.ReadLine();
                Console.WriteLine("Введите количество товара: "); kolTr = Console.ReadLine();
               
                           
                tr[i] = new Tovar(nameTr,priceTr,kolTr);

                if (priceTr.Length != 0)
                {

                    summer += Convert.ToDouble(priceTr);
                }
            }
            //--------------- сортировка -----------------
            int temp;
            for (int i = 0; i < tr.Length - 1; i++)
            {
                for (int j = i + 1; j < tr.Length; j++)
                {
                    if (tr[i].kolTovar > tr[j].kolTovar)
                    {
                        temp = tr[i].kolTovar;
                        tr[i].kolTovar = tr[j].kolTovar;
                        tr[j].kolTovar = temp;
                    }
                }
            }

            // вывод информации о товаре стоимостью более введенного с клавы
            Console.WriteLine("Информация о товаре! Введите цену: "); int priceS = Convert.ToInt32(Console.ReadLine());

            bool infoPrice = false;
            for (int i = 0; i < tr.Length; i++)
            {
                // если нашли первый положительный, тогда дальше ищем только полож числа числа.
                
                    if (tr[i].price > priceS)
                    {
                        Console.WriteLine($"Товар больше введенного {priceS} значения: \n" +
                            $"\n ===============================================\n" +
                            $"Стоимость товара: {tr[i].price}\n" +
                            $"Название товара: {tr[i].nameTovar}\n" +
                            $"Количество товара: {tr[i].kolTovar}\n" +
                            $"==================================================");
                        infoPrice = true; // если есть товар.

                    }
                else
                {
                    // если нашли наибольший товар , тогда пропускаем наименьшие
                    if (infoPrice == true)
                    {
                        if (tr[i].price < priceS)
                        {
                            infoPrice = true;
                            continue;
                        }
                    }

                    // если товаров нет
                    infoPrice = false;
            
                }
            }
            if(infoPrice == false)
            {
                Console.WriteLine("Соответствующее условие.)");
            }

            // ---------------------- СКЛАД ------------------ 
            bool infoSklad = true;
            Console.WriteLine("Показать информацию занесенную в склад? true or false - "); bool infoAboutSkald = Convert.ToBoolean(Console.ReadLine());
            infoSklad = infoAboutSkald;

            if (infoSklad) {
                ////проход по всем элементам массива "товара".
                Console.WriteLine("========================================================");
                foreach (Tovar info in tr)
                {
                    Console.WriteLine($"\n\nНаименование товара: {info.nameTovar} \n Стоимость товара: {info.price}\n Количество товара: {info.kolTovar}\n");
                }
                Console.WriteLine("========================================================");
                Console.WriteLine( $"Общая стоимость товаров: {summer}");
            }
           
            Console.ReadKey();
        }
    }
}

using laba7.others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7.data
{
    namespace OOP1lb.Data
    {
        /// <summary>
        /// Класс, реализующий ЖЭК
        /// </summary>
        public class Zheck
        {
            /* ПОЛЯ */

            /// <summary>
            /// Регион
            /// </summary>
            string Region;
            /// <summary>
            /// Номер ЖЭК в системе (id)
            /// </summary>
            int Number;
            /// <summary>
            /// Название ЖЭК
            /// </summary>
            string Name;
            /// <summary>
            /// Количество жителей.
            /// </summary>
            double NumberHabitians;
      
            /// <summary>
            /// Количество зданий
            /// </summary>
            double NumberOfBuildings;
            /// <summary>
            /// Счетчик элементов класса
            /// </summary>
            public static int counter = 0;

            /* СВОЙСТВА */
            public string Region1
            {
                get => Region;
                set
                {
                    if (!Functions.IsString(value)) throw new MyException("Неверное знаение поля регион");
                    Region = value;
                }
            }
            public int Number1 { get => Number; }
            public string Name1
            {
                get => Name;
                set
                {
                    if (!Functions.IsString(value)) throw new MyException("Неверное знаение поля название");
                    Name = value;
                }
            }
            public double NumberHabitians1 { get => NumberHabitians; set => NumberHabitians = value; }
            public double NumberOfBuildings1 { get => NumberOfBuildings; set => NumberOfBuildings = value; }

            /* МЕТОДЫ */

            /// <summary>
            /// Конструктор без параметров
            /// </summary>
            public Zheck()
            {

                Region = Functions.RandomString();
                Number = counter;
                NumberHabitians = 0;
                NumberOfBuildings = 0;
                Name = Functions.RandomString();
                counter++;
            }

            /// <summary>
            /// Конструктор с 7 параметрами
            /// </summary>
            /// /// <param name="region">Регион</param>
            /// <param name="name">Название</param>
            /// <param name="numberHabitians">Количество жителей</param>
            /// <param name="numberPayments">Число плательщиков</param>
            /// <param name="numberOfBuildings">Количество зданий</param>
            /// <param name="contactEmail">Почта</param>
            /// <param name="serviceArea">Площадь обслуживания</param>
            public Zheck(string region, string name, double numberHabitians, double numberOfBuildings)
            {

                Region1 = region;
                Number = counter;
                NumberHabitians1 = numberHabitians;
                NumberOfBuildings1 = numberOfBuildings;
                Name1 = name;
                counter++;
            }

            public Zheck(int num,string region, string name, double numberHabitians, double numberOfBuildings)
            {

                Region1 = region;
                Number = num;
                NumberHabitians1 = numberHabitians;
                NumberOfBuildings1 = numberOfBuildings;
                Name1 = name;
                counter++;
            }

            /// <summary>
            /// Получить id в 16 ричной СС
            /// </summary>
            /// <returns>id в 16 ричной СС</returns>
            public string GetNumberInHex()
            {
                return Convert.ToString(Number1, 16);
            }

            /// <summary>
            /// Переопределение метода ToString()
            /// </summary>
            /// <returns>Строку с информацией о ЖЭК</returns>
            public override string ToString()
            {
                return "id:" + Number + " Название: " + Name + " Число жителей: " + NumberHabitians + " Число зданий: " + NumberOfBuildings;
            }
        }
    }
}

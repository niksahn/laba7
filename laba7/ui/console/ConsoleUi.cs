using laba7.data;
using laba7.data.OOP1lb.Data;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace laba7.ui.console
{
    class ConsoleUi:ZheckVeiw
    {
        Controller _presenter;
        ZheckRepository _repo;
        private delegate void listenCommand();
        private event listenCommand _listenCommand;
        public string error { set { Console.WriteLine(value); _listenCommand.Invoke(); } }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public void Run(ZheckRepository repo)
        {
            _repo = repo;
            AllocConsole();
            _listenCommand += () =>
            {
                Console.WriteLine("Выберите команду: 1 показать список текущих объектов жэк; 2 добавить объект; 3 изменить объект; 4 удалить объект");
                var command = Console.ReadLine();
                switch(command)
                {
                    case "1": 
                    { 
                            _presenter.getZhecks();
                            break;
                    };
                    case "2":
                    {
                            var a = add();
                            if(a!=null) _presenter.addZheck(a);
                            break;
                    }
                    case "3":
                    {
                            var c = Change();
                            if(c!= null) { _presenter.changeZheck(c); }
                            break;
                    }
                    case "4": 
                    {
                            Console.WriteLine("Введите id");
                            var id = Console.ReadLine();
                            _presenter.removeZheck(Int32.Parse(id));
                            break;
                    }
                    default:
                        {
                            Console.WriteLine("Неверная команда");
                            _listenCommand.Invoke();
                            break;
                        }
                }
            };
            _repo.updated += (o, i) => { ShowZheckList(i); };

            _listenCommand.Invoke();
        }

        public void SetController(Controller controller)
        {
            _presenter = controller;
        }

        Zheck add()
        {
            try
            {
                Console.WriteLine("Введите название добавляемого объекта");
                var name = Console.ReadLine();
                Console.WriteLine("Введите регион добавляемого объекта");
                var region = Console.ReadLine();
                Console.WriteLine("Введите число жителей добавляемого объекта");
                var numberHab = Console.ReadLine();
                Console.WriteLine("Введите число зданий добавляемого объекта");
                var numberBuild = Console.ReadLine();
                return new Zheck(
                    region: region,
                    name: name,
                    numberHabitians: Int32.Parse(numberHab),
                    numberOfBuildings: Int32.Parse(numberBuild)
                );
            } catch(Exception e)
            {
                error = "Неврное значение одного из полей"; 
            }
            return null;
        }

        Zheck Change() {
            Console.WriteLine("Введите id изменяемого объекта");
            var id = Console.ReadLine();
            Console.WriteLine("Введите название изменяемого объекта");
            var name = Console.ReadLine();
            Console.WriteLine("Введите регион изменяемого объекта");
            var region = Console.ReadLine();
            Console.WriteLine("Введите число жителей изменяемого объекта");
            var numberHab = Console.ReadLine();
            Console.WriteLine("Введите число зданий изменяемого объекта");
            var numberBuild = Console.ReadLine();
            return new Zheck(
                region: region,
                num: Int32.Parse(id),
                name: name,
                numberHabitians: Int32.Parse(numberHab),
                numberOfBuildings: Int32.Parse(numberBuild)
            );
        }

        public void ShowZheckList(List<Zheck> zheckList)
        {
           foreach(var z in zheckList)
           {
                Console.WriteLine(z);
           }
           if(zheckList.Count == 0) { Console.WriteLine("Список пока пуст"); }
            _listenCommand.Invoke();
        }
    }
}

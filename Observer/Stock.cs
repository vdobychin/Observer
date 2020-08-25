using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Stock : IObservable //Биржа валютная (реализация наблюдаемого объекта)
    {
        StockInfo sInfo; // информация о торгах

        List<IObserver> observers; //Список наблюдателей
        public Stock()
        {
            observers = new List<IObserver>();
            sInfo = new StockInfo();
        }

        public void RegisterObserver(IObserver o) //Добавить наблюдателя
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)   //Удалить наблюдателя
        {
            observers.Remove(o);
        }

        public void NotifyObservers()             //Оповестить всех наблюдателей
        {
            foreach (IObserver o in observers)
            {
                o.Update(sInfo);
            }
        }

        public void Market() //Имитация торгов
        {
            Random rnd = new Random();
            sInfo.USD = rnd.Next(20, 40);
            sInfo.Euro = rnd.Next(30, 50);
            NotifyObservers();
        }
    }
}

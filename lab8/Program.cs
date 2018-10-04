using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab8
{
    class Program
    {

      

        static void Main(string[] args)
        {

            #region Сериализация
            void SerializeSet(string path, Set<Flower> set)
            {
                XmlSerializer ser = new XmlSerializer(typeof(Set<Flower>));
                FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                try
                {
                    ser.Serialize(file, set);
                }
                catch
                {
                    Console.WriteLine("Не удалось сериализовать множество");
                }

                finally
                {
                    file.Close();
                }
            }

            Set<Flower> DeserializeSet(string path)
            {
                XmlSerializer ser = new XmlSerializer(typeof(Set<Flower>));
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
                Set < Flower > set = new Set<Flower>();

                try
                {
                    set = (Set<Flower>)ser.Deserialize(file);
                }
                catch
                {
                    Console.WriteLine("Не удалось десериализовать множество");
                }
                finally
                {
                    file.Close();
                }

                return set;
            }
            #endregion


            //Set<int> set1 = new Set<int>(); // ограничение на ссылочный тип
            Set<string> set2 = new Set<string>() { "1", "2345"};
            Set<Flower> flowers = new Set<Flower>() { new Flower("Rose", "Red"), new Flower("Cactus", "Green"), new Flower("Another Rose", "White") };
            Set<Flower> deserializedFlowers = new Set<Flower>();

            try
            {
                string path = @"C:\\Users\\eugen\\source\repos\\lab8\\Log.txt";
                SerializeSet(path, flowers);
                deserializedFlowers = DeserializeSet(path);
                deserializedFlowers.Print();
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так");
            }

            finally
            {
                Console.WriteLine("\n");
                Console.WriteLine("Выполнение программы завершено");
            }
        }
    }
}

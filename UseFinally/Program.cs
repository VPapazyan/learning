using System;
using System.IO;
using System.Runtime.Serialization;

namespace UseFinally
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private void SomeMethod()
        {
            // Открытие файла
            FileStream fs = new FileStream(@"C:\Data.bin ", FileMode.Open);
            try
            {
                // Вывод частного от деления 100 на первый байт файла
                Console.WriteLine(100 / fs.ReadByte());
            }
            finally
            {
                // В блоке finally размещается код очистки, гарантирующий
                // закрытие файла независимо от того, возникло исключение
                // (например, если первый байт файла равен 0) или нет
                fs.Close();
            }
        }

        private void SomeMethodUsing()
        {
            using (FileStream fs =
            new FileStream(@"C:\Data.bin", FileMode.Open))
            {
                // Вывод частного от деления 100 на первый байт файла
                Console.WriteLine(100 / fs.ReadByte());
            }
        }

        public String CalculateSpreadsheetCell(Int32 row, Int32 column)
        {
            String result;
            try
            {
                result = $"{row * column}";/* Код для расчета значения ячейки электронной таблицы */
}
            catch (DivideByZeroException)
            {
                result = "Нельзя отобразить значение: деление на ноль";
            }
            catch (OverflowException)
            {
                result = "Нельзя отобразить значение: оно слишком большое";
            }
            return result;
        }

        public void SerializeObjectGraph(FileStream fs,
                                                IFormatter formatter, Object rootObj)
        {
            // Сохранение текущей позиции в файле
            Int64 beforeSerialization = fs.Position;
            try
            {
                // Попытка сериализовать граф объекта и записать его в файл
                formatter.Serialize(fs, rootObj);
            }
            catch
            { // Перехват всех исключений
              // При ЛЮБОМ повреждении файл возвращается в нормальное состояние
                fs.Position = beforeSerialization;
                // Обрезаем файл
                fs.SetLength(fs.Position);
                // ПРИМЕЧАНИЕ: предыдущий код не помещен в блок finally,
                // так как сброс потока требуется только при сбое сериализации
                // Уведомляем вызывающий код о происходящем,
                // снова генерируя ТО ЖЕ САМОЕ исключение
                throw;
            }
        }
    }
}

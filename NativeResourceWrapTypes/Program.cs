using System;
using System.IO;

namespace NativeResourceWrapTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            // Create the bytes to write to the temporary file.
            Byte[] bytesToWrite = new Byte[] { 1, 2, 3, 4, 5 };
            // Create the temporary file.
            FileStream fs = new FileStream("Temp.dat", FileMode.Create);
            // Write the bytes to the temporary file.
            fs.Write(bytesToWrite, 0, bytesToWrite.Length);
            // Delete the temporary file.
            File.Delete("Temp.dat"); // Throws an IOException
            #endregion

            #region
            // Create the bytes to write to the temporary file.
            Byte[] bytesToWrite1 = new Byte[] { 1, 2, 3, 4, 5 };
            // Create the temporary file.
            FileStream fs1 = new FileStream("Temp.dat", FileMode.Create);
            // Write the bytes to the temporary file.
            fs1.Write(bytesToWrite, 0, bytesToWrite.Length);
            // Explicitly close the file when finished writing to it.
            fs1.Dispose();
            // Delete the temporary file.
            File.Delete("Temp.dat"); // This always works now.
            #endregion

            #region
            // Create the bytes to write to the temporary file.
            Byte[] bytesToWrite2 = new Byte[] { 1, 2, 3, 4, 5 };
            // Create the temporary file.
            FileStream fs2 = new FileStream("Temp.dat", FileMode.Create);
            try
            {
                // Write the bytes to the temporary file.
                fs.Write(bytesToWrite, 0, bytesToWrite.Length);
            }
            finally
            {
                // Explicitly close the file when finished writing to it.
                if (fs != null) fs.Dispose();
            }
            // Delete the temporary file.
            File.Delete("Temp.dat");
            #endregion

            #region
            // Создание байтов для записи во временный файл
            Byte[] bytesToWrite3 = new Byte[] { 1, 2, 3, 4, 5 };
            // Создание временного файла
            using (FileStream fs3 = new FileStream("Temp.dat", FileMode.Create))
            {
                // Запись байтов во временный файл
                fs.Write(bytesToWrite, 0, bytesToWrite.Length);
            }
            // Удаление временного файла
            File.Delete("Temp.dat");
            #endregion
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncFirstLook
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Fun With Async ===>");
            //string message = await DoWorkAsync();
            //Console.WriteLine(message);
            //Console.WriteLine("Completed");
            //Console.ReadLine();
            await MultipleAwaits();

            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }
        }

        static string DoWork()
        {
            Thread.Sleep(5_000);
            return "Done with work!";
        }

        static async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5_000);
                return "Done with async work!";
            });
        }

        static async Task MultipleAwaits()
        {
            var task1 = Task.Run(() =>
            {
                Thread.Sleep(2_000);
                Console.WriteLine("Done with first task!");
            });

            var task2 = Task.Run(() =>
            {
                Thread.Sleep(1_000);
                Console.WriteLine("Done with second task!");
            });
            var task3 = Task.Run(() =>
            {
                Thread.Sleep(1_000);
                Console.WriteLine("Done with third task!");
            });
            await Task.WhenAll(task1, task2, task3);
            await Task.WhenAny(task1, task2, task3);
        }

        static async Task<string> MethodWithTryCatch()
        {
            try
            {
                //Do some work
                return "Hello";
            }
            catch (Exception ex)
            {
                //await LogTheErrors();
                throw;
            }
            finally
            {
                //await DoMagicCleanUp();
            }
        }

        static async ValueTask<int> ReturnAnInt()
        {
            await Task.Delay(1_000);
            return 5;
        }

        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }

    }
}

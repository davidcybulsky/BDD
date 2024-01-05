using BenchmarkDotNet;
using Api.Services;
using Api.Entities;
using BenchmarkDotNet.Running;

namespace Api.Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            BenchmarkRunner.Run<AnimalServiceBenchmark>();
            BenchmarkRunner.Run<CaretakerServiceBenchmark>();
            BenchmarkRunner.Run<TicketServiceBenchmark>();
            BenchmarkRunner.Run<UserServiceBenchmark>();
        }
    }
}
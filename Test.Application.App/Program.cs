using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions;
using Test.Application.Core.Interfaces;
using Test.Application.Core.Static;
using Test.Application.Domain.Services;
using Console.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Test.Application.App;
using Test.Application.Infrastructure.Repositories;
using Test.Application.App.ClassCollections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        MainMenu();
    }

    static void MainMenu()
    {
        var key = "b14ca5898a4e4133bbce2ea2315a1916";

        var builder = new ConfigurationBuilder()
                   .AddJsonFile($"appsettings.json", true, true);

        var config = builder.Build();
        string? connectionString = config["ConnectionStrings:DefaultConnection"];

        ServiceCollection serviceProvider = new();
        serviceProvider.AddDbContext<AdventureWorksContext>(options =>
        options.UseSqlServer(EncryptAes.DecryptString(key, connectionString)));

        serviceProvider.AddSingleton<IEmployeeService, EmployeeService>();
        serviceProvider.AddSingleton<IRepository, Repository>();

        Injector.GenerarProveedor(serviceProvider);
        IEmployeeService generador = Injector.GetService<IEmployeeService>();

        System.Console.Clear();
        System.Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine("Managment Employees \n" +
        "\n1.- Get list of employees" +
        "\n2.- Insert employees from file" +
        "\n3.- Download file csv" +
        "\n4.- Exit" +
        "\nSelect your choise: ", System.Console.ForegroundColor
        );

        string? option;
        option = System.Console.ReadLine();

        switch (option)
        {
            case "1":
                System.Console.Clear();
                System.Console.ForegroundColor = ConsoleColor.Green;
                generador.GetEmployees();
                System.Console.ReadLine();
                break;
            case "2":
                System.Console.Clear();
                System.Console.ForegroundColor = ConsoleColor.Green;
                generador.LoadRecords();
                break;
            case "3":
                System.Console.Clear();
                System.Console.ForegroundColor = ConsoleColor.Green;
                generador.GetFile();
                break;
            case "4":
                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine(GeneralMessages.BYE);
                System.Console.WriteLine(GeneralMessages.CONFIRM);

                string? close = string.Empty;
                close = System.Console.ReadLine();

                if (close.ToUpper() == "Y")
                {
                    Environment.Exit(1);
                    break;
                }
                else
                {
                    break;
                }
            default:
                System.Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine(GeneralMessages.ERROROPMENU);
                System.Console.ReadLine();
                break;
        }

        MainMenu();
    }
}
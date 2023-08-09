using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions;
using Test.Application.Core.Interfaces;
using Test.Application.Core.Static;
using Test.Application.Domain.Services;
using Console.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Test.Application.App;
using Test.Application.Infrastructure.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {

        MainMenu();
    }

    static void MainMenu()
    {
        ServiceCollection serviceProvider = new();
        serviceProvider.AddDbContext<AdventureWorksContext>(options =>
        options.UseSqlServer("Server=.\\SQLTEST;Database=AdventureWorks;User ID=BGMTESTUSER;Password=T35t.2023.*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;"));

        serviceProvider.AddSingleton<IEmployeeService, EmployeeService>();
        serviceProvider.AddSingleton<IRepository, Repository>();

        Injector.GenerarProveedor(serviceProvider);
        //Obtengo clase desde el IOC
        IEmployeeService generador = Injector.GetService<IEmployeeService>();

        System.Console.Clear();
        System.Console.WriteLine("Managment Employees \n" +
        "\n1.- Get list of employees" +
        "\n2.- Insert employees data" +
        "\n3.- Download file" +
        "\n4.- Exit" +
        "\nSelect your choise: "
        );

        string? option;
        option = System.Console.ReadLine();

        switch (option)
        {
            case "1":
                generador.GetEmployees();
                System.Console.ReadLine();
                break;
            case "2":
                //Triangle triangle = new();
                //triangle.CalculateTriangleArea();
                break;
            case "3":
                //Triangle triangle = new();
                //triangle.CalculateTriangleArea();
                break;
            case "4":
                System.Console.WriteLine(GeneralMessages.BYE);
                System.Console.WriteLine(GeneralMessages.CONFIRM);
                System.Console.ReadLine();
                Environment.Exit(1);
                break;
            default:
                System.Console.WriteLine(GeneralMessages.ERROROPMENU);
                System.Console.ReadLine();
                break;
        }

        MainMenu();
    }
}
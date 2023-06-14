/***************************************************************************************************
* Name: Jeyma Rodriguez
* FSUID: jdr21d
* COP4870 
* Professor: Christopher Mills
* Assignment 1
****************************************************************************************************/
using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;
using System;

namespace PracticePanther // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Client> clients = new List<Client>();
            List<Project> projects = new List<Project>();

            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("Hello there! Make a selection to see a Client or Project MENU. Select T for client or P for project: ");

                string userSelect = Console.ReadLine() ?? string.Empty;

                if (userSelect.Equals("T", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientMenu();
                }
                else if (userSelect.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProjectMenu(projects);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option: ");
                }
                Console.WriteLine();
            }
        }

        /******************************************** Client Menu **********************************************/
        static void ClientMenu()
        {
            var clientService = ClientService.Current;
            bool quit = false;
            while (!quit)    //using while loop for menu selection
            {
                Console.WriteLine("Select an option from the MENU: ");
                Console.WriteLine("(C) Create a new client");
                Console.WriteLine("(R) Read client information");
                Console.WriteLine("(U) Update client information");
                Console.WriteLine("(D) Delete a client");
                Console.WriteLine("(M) Go to initial MENU");
                Console.WriteLine("(Q) Quit program");

                string option = Console.ReadLine() ?? string.Empty;

                if (option.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Id: ");
                    var Id = int.Parse(Console.ReadLine() ?? "0");

                    Console.Write("Name: ");
                    var name = Console.ReadLine() ?? string.Empty;   //reading user input client name

                    Console.WriteLine("Note: ");
                    string notes = Console.ReadLine() ?? string.Empty;

                    ClientService.Current.Add(    //creating new client 
                        new Client
                        {
                            Id = Id,
                            OpenDate = DateTime.Now,
                            ClosedDate = DateTime.MinValue,
                            IsActive = true,
                            Name = name,
                            Notes = notes
                        }
                    );
                    Console.WriteLine("Client created successfully");
                }
                else if (option.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientService.Current.Read();
                }
                else if (option.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Which client should be updated? Enter client ID: ");
                    clientService.Read();
                    var updChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientToUpdate = clientService.Get(updChoice);
                    if (clientToUpdate != null)
                    {
                        Console.WriteLine("Enter client new information ");
                        Console.WriteLine("Name: ");
                        clientToUpdate.Name = Console.ReadLine() ?? "Jhon/Jane Doe";
                        Console.WriteLine("Client updated successfully");

                    }
                    else { Console.WriteLine("Client not founded"); }
                }
                else if (option.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Which client should be deleted? Enter client ID: ");
                    clientService.Read();
                    var deleteChoice = int.Parse(Console.ReadLine() ?? string.Empty);
                    clientService.Remove(deleteChoice);

                }
                else if (option.Equals("M", StringComparison.InvariantCultureIgnoreCase))
                {
                    quit = true;    //exit client menu loop
                }
                else if (option.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    Environment.Exit(0);    //exit program
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry, that functionality is not supported");
                }
                Console.WriteLine();
            }
        }

        /******************************************** Project Menu **********************************************/
        static void ProjectMenu(List<Project> projects)
        {
            var projectService = ProjectService.CurrentProj;
            bool quit = false;
            while (!quit)    //using while loop for menu selection
            {
                Console.WriteLine("Select an option from the MENU: ");
                Console.WriteLine("(C) Create a new project");
                Console.WriteLine("(R) Read project details");
                Console.WriteLine("(U) Update project details");
                Console.WriteLine("(D) Delete a project");
                Console.WriteLine("(L) Link project to client");
                Console.WriteLine("(M) Go to initial MENU");
                Console.WriteLine("(Q) Quit program");

                string option = Console.ReadLine() ?? string.Empty;

                if (option.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter project details:");
                    Console.Write("Short Name: ");
                    string shortName = Console.ReadLine() ?? "0";

                    Console.Write("Long Name: ");
                    string longName = Console.ReadLine() ?? "0";

                    Console.Write("Project ID: ");
                    var Id = int.Parse(Console.ReadLine() ?? "0");

                    ProjectService.CurrentProj?.Add(
                        new Project
                        {
                            Id = Id,
                            OpenDate = DateTime.Now,
                            ClosedDate = DateTime.MinValue,
                            IsActive = true,
                            ShortName = shortName,
                            LongName = longName,

                        }
                    );
                    Console.WriteLine("Project created successfully");

                }
                else if (option.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProjectService.CurrentProj?.Read();
                }
                else if (option.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Which project should be updated: ");
                    projectService?.Read();
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var projectToUpd = projectService?.Get(updateChoice);
                    if (projectToUpd != null)
                    {
                        Console.WriteLine("Enter new project information: ");
                        Console.WriteLine("Short Name: ");
                        string shortName = Console.ReadLine() ?? "0";

                        Console.WriteLine("Long Name: ");
                        string longName = Console.ReadLine() ?? "0";

                        projectToUpd.ShortName = shortName;
                        projectToUpd.LongName = longName;

                        Console.WriteLine("Project updated successfully");
                    }
                    else { Console.WriteLine("Project not found"); }
                }
                else if (option.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.Write("Which project should be deleted: ");
                    projectService?.Read();
                    Console.Write("Enter project ID: ");
                    var deletChoice = int.Parse(Console.ReadLine() ?? "0");
                    projectService?.Remove(deletChoice);

                }
                else if (option.Equals("L", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientService clientService = ClientService.Current;
                    Console.WriteLine("Project Id: ");
                    int projectId = int.Parse(Console.ReadLine() ?? "0");

                    Project? project = projectService?.Get(projectId);
                    if (project != null)
                    {
                        Console.WriteLine("Enter the Id of the selected client to link to a project: ");
                        int.TryParse(Console.ReadLine(), out int clientId);

                        Client? client = clientService?.Get(clientId);
                        if (client != null)
                        {
                            project.ClientId = clientId;
                            Console.WriteLine("Project linked to client successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Client not found.");
                        }

                    }
                    else { Console.WriteLine("Project not found"); }
                }
                else if (option.Equals("M", StringComparison.InvariantCultureIgnoreCase))
                {
                    quit = true;    //exit project menu loop
                }
                else if (option.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    Environment.Exit(0);  //exit program
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry, that functionality is not supported");
                }
                Console.WriteLine();
            }
        }
    }
}
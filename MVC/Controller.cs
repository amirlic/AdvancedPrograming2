﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;

namespace MVC
{
    class Controller
    {
        private Dictionary<string, ICommand> commands;
        private Model model;
        private Dictionary<string, List<TcpClient>> playersInMazeList;

        public Controller()
        {
            model = new Model();
            commands = new Dictionary<string, ICommand>();
            commands.Add("generate", new GenerateMazeCommand(model));
            commands.Add("list", new ListCommand(model));
            commands.Add("start", new StartCommand(model));
            commands.Add("join", new JoinCommand(model));
            commands.Add("play", new ListCommand(model));
            commands.Add("cose", new ListCommand(model));
            // more commands...
        }
        public string ExecuteCommand(string commandLine, TcpClient client)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                return "Command not found";
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            string result = command.Execute(args, client);
            return result;
        }
    }
}

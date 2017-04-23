﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;

namespace MVC
{
    class PlayCommand : ICommand
    {
        private IModel model;
        public PlayCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            MultiPlayerGame game = model.Start(name, rows, cols);
            model.ConnectToGame(name, client);
            Maze maze = game.GetMaze();
            return maze.ToJSON();
        }
    }
}

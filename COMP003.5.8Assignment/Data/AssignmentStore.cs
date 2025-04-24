using COMP003._5._8Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003._5._8Assignment.Data
{
    public static class AssignmentStore
    {
        public static List<Assignment> Assignments { get; } = new()
    {
        new Assignment { Id = 1, Name = "Math HomeWork", Subject = "Math"},
        new Assignment { Id = 2, Name = "Eng. HomeWork", Subject = "English" },
        new Assignment { Id = 3, Name = "Comp. HomeWork", Subject = "ASP.NET" }
    };
    }
    }

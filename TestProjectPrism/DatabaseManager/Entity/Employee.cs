﻿using System;

namespace TestProjectPrism.DatabaseManager.Entity
{
    public partial class Employee
    {
        public int Id { get; set; }

        public string LastName { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Patronymic { get; set; }

        public string DateOfBirth { get; set; } = null!;

        public long Telephone { get; set; }

        public string Email { get; set; } = null!;

        public int DepartmentId { get; set; }

        public int PositionId { get; set; }

        public Department Department { get; set; } = null!;

        public Position Position { get; set; } = null!;
    }
}
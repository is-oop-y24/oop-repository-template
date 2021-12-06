using System;

namespace Reports.DAL.Entities
{
    public class Employee
    {
        public Guid Id { get; private init; }

        public string Name { get; private init; }

        private Employee()
        {
        }

        public Employee(Guid id, string name)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id), "Id is invalid");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Name is invalid");
            }

            Id = id;
            Name = name;
        }
    }
}
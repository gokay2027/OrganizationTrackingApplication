﻿using Entities.BaseAggregate.Concrete;
using Entities.Domain;

namespace Entities.Entities
{
    public class EventType : BaseEntity
    {
        public string Name { get; private set; }

        public List<Event> Events { get; private set; } = new List<Event>();

        public EventType()
        {
        }

        public EventType(string typeName)
        {
            Name = typeName;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
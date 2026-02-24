using System.Collections.Generic;
using System.Linq;
using EcommerceAPI.Domain.Common;
using Xunit;

namespace EcommerceAPI.Domain.Tests
{
    public class BaseEntityTests
    {
        private class TestDomainEvent : IDomainEvent { }

        private class TestEntity : BaseEntity
        {
            public string Name { get; set; }

            public TestEntity(string name)
            {
                Name = name;
            }

            public void AddEvent(IDomainEvent domainEvent) => AddDomainEvent(domainEvent);
        }

        [Fact]
        public void DomainEvent_ShouldBeEmpty_WhenEntityIsCreated()
        {
            var entity = new TestEntity("Test");

            var events = entity.DomainEvents;

            Assert.Empty(events);
        }

        [Fact]
        public void AddDomainEvent_ShouldAddEvent_ToDomainEventCollection()
        {
            var entity = new TestEntity("Test");
            var domainEvent = new TestDomainEvent();

            entity.AddEvent(domainEvent);
            var events = entity.DomainEvents;

            Assert.Single(events);
            Assert.Contains(domainEvent, events.ToList());
        }

        [Fact]
        public void ClearDomainEvents_ShouldRemoveAllEvents_FromDomainEventCollection()
        {
            var entity = new TestEntity("Test");
            entity.AddEvent(new TestDomainEvent());
            entity.AddEvent(new TestDomainEvent());

            entity.ClearDomainEvents();
            var events = entity.DomainEvents;

            Assert.Empty(events);
        }
    }
}

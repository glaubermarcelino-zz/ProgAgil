using System;

namespace apiTrello.Domain
{
    public abstract class Base
    {
        public Base()
        {
            Key = Guid.NewGuid();
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdate { get; set; }
        public Guid Key { get; set; }

    }
}

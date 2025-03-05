using Newtonsoft.Json;
using System;

namespace Company.Function
{
    public class Counter
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); // Initialize the property
        public int Count { get; set; }
    }
}
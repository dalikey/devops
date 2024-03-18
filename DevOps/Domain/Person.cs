namespace DevOps.Domain {
    public abstract class Person {
        public string Name { get; set; }
        public Person(string Name) {
            this.Name = Name;
        }
    }
}


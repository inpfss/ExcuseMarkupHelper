using System;

namespace ExcusesCoreLogic
{
    public class Tactic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label => $"{Id + 1}. {Name}"; 

        public override string ToString() => Id.ToString();

        public override int GetHashCode() { return Id.GetHashCode(); }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this,obj))
            {
                return true;
            }

            Tactic t2=obj as Tactic;
            return t2 != null && t2.Id == Id;
        }
    }
}
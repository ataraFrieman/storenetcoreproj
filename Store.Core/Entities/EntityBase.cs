using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Core.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public DateTime TimeUpdated { get; set; }
        public int? LastUpdateUserId { get; set; }
        public int CreatedUserId { get; set; }
        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            return GetType().Name + '-' + Id;
        }

        [NotMapped]
        protected bool IsNew => Id == 0;


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            var objAsBase = obj as EntityBase;
            return !IsNew ? Id == objAsBase.Id : base.Equals(obj);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {

            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
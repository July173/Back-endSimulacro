using System;

namespace Entity.Model.Base
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}

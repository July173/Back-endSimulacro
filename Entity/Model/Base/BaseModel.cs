using System;

namespace Entity.Model.Base
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}

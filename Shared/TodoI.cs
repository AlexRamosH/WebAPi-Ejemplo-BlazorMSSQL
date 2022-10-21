using System;
using System.Collections.Generic;

namespace BlazorApp3.Shared
{
    public partial class TodoI
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Terminado { get; set; }
    }
}

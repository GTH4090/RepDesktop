﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RepDesktop.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RepDbEntities2 : DbContext
    {
        public RepDbEntities2()
            : base("name=RepDbEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Flooor2ForMessage> Flooor2ForMessage { get; set; }
        public virtual DbSet<Floor1ForMessage> Floor1ForMessage { get; set; }
        public virtual DbSet<Floor3forMessage> Floor3forMessage { get; set; }
        public virtual DbSet<Flor4ForMessage> Flor4ForMessage { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<WindowsForRoom> WindowsForRoom { get; set; }
    }
}
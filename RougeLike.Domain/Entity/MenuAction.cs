﻿using RougeLike.Domain.Common;

namespace RougeLike.Domain.Entity
{
    public class MenuAction : BaseEntity
    {
        public string MenuName { get; set; }

        public MenuAction(int id, string name, string menuName)
        {
            Id = id;
            Name = name;
            MenuName = menuName;
        }
    }
}
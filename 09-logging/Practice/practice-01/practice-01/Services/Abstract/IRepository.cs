﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_01.Services.Abstract
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T item);
    }
}

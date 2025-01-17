﻿using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWorkMessage : IDisposable
    {
        IMessageRepository MessageRepository { get; }

        void Complete();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface IFinancialTransactionService
    {
        Task<bool> CreateFinancialTransaction(int id, FinancialTransactionDTO transaction);
        Task<IEnumerable<FinancialTransactionDTO>> GetFinancialTransactions();
    }
}

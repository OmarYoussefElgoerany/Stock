﻿using StockDAL.Data.Models;
using StockDAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDAL
{
    public interface IItemRepo:IGenericRepo<Item>
    {
    }
}

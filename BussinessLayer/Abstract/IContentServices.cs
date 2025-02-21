﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IContentServices
    {
        List<Content> GetList();
        List<Content> GetListById(int id);
        void ContentAdd(Content content);
        Content GetById(int id);
        void ContentyDelete(Content content);
        void ContentUpdate(Content content);
    }
}
